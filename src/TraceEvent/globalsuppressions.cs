#nullable disable

// This file is used by Code Analysis to maintain SuppressMessage 
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given 
// a specific target and scoped to a namespace, type, member, etc.
//
// To add a suppression to this file, right-click the message in the 
// Code Analysis results, point to "Suppress Message", and click 
// "In Suppression File".
// You do not need to add suppressions to this file manually.

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable", Scope = "type", Target = "Utilities.Command")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable", Scope = "type", Target = "Microsoft.Diagnostics.Tracing.TraceLogOptions")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1001:TypesThatOwnDisposableFieldsShouldBeDisposable", Scope = "type", Target = "Microsoft.Diagnostics.Tracing.Etlx.TraceLogOptions")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1060:MovePInvokesToNativeMethodsClass", Scope = "member", Target = "Dia2Lib.DiaLoader.#DllGetClassObject(System.Guid,System.Guid)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1060:MovePInvokesToNativeMethodsClass", Scope = "member", Target = "NativeDlls.#LoadLibrary(System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1060:MovePInvokesToNativeMethodsClass", Scope = "member", Target = "Microsoft.Diagnostics.Tracing.Parsers.RegisteredTraceEventParser.#TdhGetEventInformation(Microsoft.Diagnostics.Tracing.Parsers.TraceEventNativeMethods+EVENT_RECORD*,System.UInt32,System.Void*,System.Byte*,System.Int32*)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1060:MovePInvokesToNativeMethodsClass", Scope = "member", Target = "Microsoft.Diagnostics.Tracing.Parsers.Kernel.KernelToUserDriveMapping.#QueryDosDevice(System.String,System.Text.StringBuilder,System.Int32)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1060:MovePInvokesToNativeMethodsClass", Scope = "member", Target = "Microsoft.Diagnostics.Tracing.Parsers.Kernel.KernelToUserDriveMapping.#GetLogicalDrives()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1060:MovePInvokesToNativeMethodsClass", Scope = "member", Target = "Microsoft.Diagnostics.Tracing.Parsers.RegisteredTraceEventParser.#TdhGetEventMapInformation(Microsoft.Diagnostics.Tracing.Parsers.TraceEventNativeMethods+EVENT_RECORD*,System.String,Microsoft.Diagnostics.Tracing.Parsers.RegisteredTraceEventParser+EVENT_MAP_INFO*,System.Int32&)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Target = "Microsoft.Diagnostics.Tracing.TraceEventSource.#Microsoft.Diagnostics.Tracing.ITraceParserServices.RegisterEventTemplate(Microsoft.Diagnostics.Tracing.TraceEvent)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Target = "Microsoft.Diagnostics.Tracing.TraceEventSource.#Microsoft.Diagnostics.Tracing.ITraceParserServices.UnregisterEventTemplate(System.Delegate,System.Int32,System.Guid)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Target = "Microsoft.Diagnostics.Tracing.TraceEventSource.#Microsoft.Diagnostics.Tracing.ITraceParserServices.RegisterParser(Microsoft.Diagnostics.Tracing.TraceEventParser)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Target = "Microsoft.Diagnostics.Tracing.TraceEventSource.#Microsoft.Diagnostics.Tracing.ITraceParserServices.RegisterUnhandledEvent(System.Func`2<Microsoft.Diagnostics.Tracing.TraceEvent,Microsoft.Diagnostics.Tracing.TraceEvent>)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Target = "Microsoft.Diagnostics.Tracing.TraceEventSource.#Microsoft.Diagnostics.Tracing.ITraceParserServices.TaskNameForGuid(System.Guid)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes", Scope = "member", Target = "Microsoft.Diagnostics.Tracing.TraceEventSource.#Microsoft.Diagnostics.Tracing.ITraceParserServices.ProviderNameForGuid(System.Guid)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly", Scope = "member", Target = "Microsoft.Diagnostics.Tracing.Parsers.Kernel.VirtualAllocTraceData.#Action")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly", Scope = "member", Target = "Microsoft.Diagnostics.Tracing.Parsers.Kernel.StackWalkDefTraceData.#Action")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly", Scope = "member", Target = "Microsoft.Diagnostics.Tracing.Parsers.Kernel.StackWalkTraceData.#Action")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly", Scope = "member", Target = "Microsoft.Diagnostics.Tracing.Parsers.Kernel.StackWalkRefTraceData.#Action")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly", Scope = "member", Target = "Microsoft.Diagnostics.Tracing.Parsers.Kernel.ReadyThreadTraceData.#Action")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly", Scope = "member", Target = "Microsoft.Diagnostics.Tracing.TraceEventParser.#All")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly", Scope = "member", Target = "Microsoft.Diagnostics.Tracing.TraceEventDispatcher.#UnhandledEvent")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly", Scope = "member", Target = "Microsoft.Diagnostics.Tracing.TraceEventDispatcher.#EveryEvent")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly", Scope = "member", Target = "Microsoft.Diagnostics.Tracing.TraceEventDispatcher.#Completed")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2002:DoNotLockOnObjectsWithWeakIdentity", Scope = "member", Target = "FastSerialization.IOStreamStreamReader.#Fill(System.Int32)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1016:MarkAssembliesWithAssemblyVersion")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1060:MovePInvokesToNativeMethodsClass", Scope = "member", Target = "Microsoft.Diagnostics.Tracing.Parsers.KernelToUserDriveMapping.#QueryDosDevice(System.String,System.Text.StringBuilder,System.Int32)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1060:MovePInvokesToNativeMethodsClass", Scope = "member", Target = "Microsoft.Diagnostics.Tracing.Parsers.KernelToUserDriveMapping.#GetLogicalDrives()")]










