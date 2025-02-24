#nullable disable

using FastSerialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TraceEventTests
{
    internal class FastSerializerTests
    {
        [Fact]
        public void ParseEightByteStreamLabel()
        {
            MemoryStream ms = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(ms);
            WriteString(writer, "!FastSerialization.1");
            writer.Write((long)0);
            writer.Write((long)19);
            writer.Write((long)1_000_000);
            writer.Write((long)0xf1234567);

            ms.Position = 0;
            Deserializer d = new Deserializer(new PinnedStreamReader(ms, config: new SerializationConfiguration() { StreamLabelWidth = StreamLabelWidth.EightBytes }), "name");
            Assert.Equal((StreamLabel)0, d.ReadLabel());
            Assert.Equal((StreamLabel)19, d.ReadLabel());
            Assert.Equal((StreamLabel)1_000_000, d.ReadLabel());
            Assert.Equal((StreamLabel)0xf1234567, d.ReadLabel());
        }

        [Fact]
        public void ParseFourByteStreamLabel()
        {
            MemoryStream ms = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(ms);
            WriteString(writer, "!FastSerialization.1");
            writer.Write(0);
            writer.Write(19);
            writer.Write(1_000_000);
            writer.Write(0xf1234567);

            ms.Position = 0;
            Deserializer d = new Deserializer(new PinnedStreamReader(ms, config: new SerializationConfiguration() { StreamLabelWidth = StreamLabelWidth.FourBytes }), "name");
            Assert.Equal((StreamLabel)0, d.ReadLabel());
            Assert.Equal((StreamLabel)19, d.ReadLabel());
            Assert.Equal((StreamLabel)1_000_000, d.ReadLabel());
            Assert.Equal((StreamLabel)0xf1234567, d.ReadLabel());
        }

        private void WriteString(BinaryWriter writer, string val)
        {
            writer.Write(val.Length);
            writer.Write(Encoding.UTF8.GetBytes(val));
        }

        [Fact]
        public void WriteAndParseFourByteStreamLabel()
        {
            SampleSerializableType sample = new SampleSerializableType(SampleSerializableType.ConstantValue);
            MemoryStream ms = new MemoryStream();
            Serializer s = new Serializer(new IOStreamStreamWriter(ms, leaveOpen:true, config: new SerializationConfiguration() { StreamLabelWidth = StreamLabelWidth.FourBytes }), sample);
            s.Dispose();

            Deserializer d = new Deserializer(new PinnedStreamReader(ms, config: new SerializationConfiguration() { StreamLabelWidth = StreamLabelWidth.FourBytes }), "name");
            d.RegisterFactory(typeof(SampleSerializableType), () => new SampleSerializableType(0));
            SampleSerializableType serializable = (SampleSerializableType)d.ReadObject();
            Assert.Equal(SampleSerializableType.ConstantValue, serializable.BeforeValue);
            Assert.Equal(SampleSerializableType.ConstantValue, serializable.AfterValue);
        }

        [Fact]
        public void WriteAndParseEightByteStreamLabel()
        {
            SampleSerializableType sample = new SampleSerializableType(SampleSerializableType.ConstantValue);
            MemoryStream ms = new MemoryStream();
            Serializer s = new Serializer(new IOStreamStreamWriter(ms, leaveOpen: true, config: new SerializationConfiguration() { StreamLabelWidth = StreamLabelWidth.EightBytes }), sample);
            s.Dispose();

            Deserializer d = new Deserializer(new PinnedStreamReader(ms, config: new SerializationConfiguration() { StreamLabelWidth = StreamLabelWidth.EightBytes }), "name");
            d.RegisterFactory(typeof(SampleSerializableType), () => new SampleSerializableType(0));
            SampleSerializableType serializable = (SampleSerializableType)d.ReadObject();
            Assert.Equal(SampleSerializableType.ConstantValue, serializable.BeforeValue);
            Assert.Equal(SampleSerializableType.ConstantValue, serializable.AfterValue);
        }
    }

    internal sealed class SampleSerializableType : IFastSerializable
    {
        public const int ConstantValue = 42;

        public SampleSerializableType(int value)
        {
            BeforeValue = value;
            AfterValue = value;
        }

        public int BeforeValue { get; set; }
        public int AfterValue { get; set; }

        void IFastSerializable.ToStream(Serializer serializer)
        {
            serializer.Write(BeforeValue);
            serializer.Writer.Write((StreamLabel)0x7EADBEEF);
            serializer.Write(AfterValue);
        }

        void IFastSerializable.FromStream(Deserializer deserializer)
        {
            BeforeValue = deserializer.ReadInt();
            StreamLabel label = deserializer.Reader.ReadLabel();
            Assert.Equal((ulong)0x7EADBEEF, (ulong)label);
            AfterValue = deserializer.ReadInt();
        }
    }
}










