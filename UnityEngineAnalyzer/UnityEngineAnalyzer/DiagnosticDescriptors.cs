using Microsoft.CodeAnalysis;

namespace UnityEngineAnalyzer
{
    static class DiagnosticDescriptors
    {
        //IMPORTANT! As part of the process of migrating to .Net Standard - Reference to resources were removed as
        // Support for resource class generation is currently limited


        //NOTES: Naming of Descriptors are a bit inconsistant
        //NOTES: The Resource Reading code seems  repetative

        public static readonly DiagnosticDescriptor DoNotUseOnGUI = new DiagnosticDescriptor(
            id: DiagnosticIDs.DoNotUseOnGUI,
            title: "Usage of OnGUI is known to cause GC and/or performance issues.",
            messageFormat: "'{0}' implements OnGUI. This is known to cause GC and/or performance issues.",
            category: DiagnosticCategories.GC,
            defaultSeverity: DiagnosticSeverity.Info,
            isEnabledByDefault: true,
            description: "Do not use OnGUI in MonoBehaviours.");

        public static readonly DiagnosticDescriptor DoNotUseStringMethods = new DiagnosticDescriptor(
            id: DiagnosticIDs.DoNotUseStringMethods,
            title: "Do not use SendMessage, SendMessageUpwards or BroadcastMessage.",
            messageFormat: "Use of SendMessage, SendMessageUpwards, BroadcastMessage, Invoke or InvokeRepeating leads to code that is hard to maintain. Consider using UnityEvent, C# event, delegates or a direct method call.",
            category: DiagnosticCategories.StringMethods,
            defaultSeverity: DiagnosticSeverity.Info,
            isEnabledByDefault: true,
            description: "Use of SendMessage, SendMessageUpwards, BroadcastMessage, Invoke or InvokeRepeating leads to code that is hard to maintain. Consider using UnityEvent, C# event, delegates or a direct method call.");

        public static readonly DiagnosticDescriptor DoNotUseCoroutines = new DiagnosticDescriptor(
            id: DiagnosticIDs.DoNotUseCoroutines,
            title: "Use of coroutines is known to cause some allocations.",
            messageFormat: "Use of coroutines is known to cause some allocations.",
            category: DiagnosticCategories.GC,
            defaultSeverity: DiagnosticSeverity.Info,
            isEnabledByDefault: true,
            description: "Use of coroutines is known to cause some allocations.");


        public static readonly DiagnosticDescriptor EmptyMonoBehaviourMethod = new DiagnosticDescriptor(
            id: DiagnosticIDs.EmptyMonoBehaviourMethod,
            title: "Remove empty MonoBehaviour methods.",
            messageFormat: "'{0}' has an empty MonoBehaviour method '{1}'. Empty MonoBehaviour methods causes some overhead.",
            category: DiagnosticCategories.Miscellaneous,
            defaultSeverity: DiagnosticSeverity.Warning,
            isEnabledByDefault: true,
            description: "Empty MonoBehaviour methods causes some overhead.");

        public static readonly DiagnosticDescriptor UseCompareTag = new DiagnosticDescriptor(
            id: DiagnosticIDs.UseCompareTag,
            title: "Use CompareTag",
            messageFormat: "Use CompareTag instead of using the Equals operator",
            category: DiagnosticCategories.GC,
            defaultSeverity: DiagnosticSeverity.Warning,
            isEnabledByDefault: true,
            description: "Comparing a Tag using Equals operator can cause unecessary memory allocation. Use the CompareTag function Instead.");

        public static readonly DiagnosticDescriptor DoNotUseFindMethodsInUpdate = new DiagnosticDescriptor(
            id: DiagnosticIDs.DoNotUseFindMethodsInUpdate,
            title: "Cache the result of Find or GetComponent in Start or Awake.",
            messageFormat: "The method {0} is called from {1}.{2} which could cause performance problems. Cache the result from {0} in Start or Awake instead.",
            category: DiagnosticCategories.Performance,
            defaultSeverity: DiagnosticSeverity.Warning,
            isEnabledByDefault: true,
            description: "Using Find or GetComponent in Update methods can impact performance. Cache the result on Start or Awake methods");

        public static readonly DiagnosticDescriptor DoNotUseFindMethodsInUpdateRecursive = new DiagnosticDescriptor(
            id: DiagnosticIDs.DoNotUseFindMethodsInUpdate,
            title: "Cache the result of Find or GetComponent in Start or Awake.",
            messageFormat: "The method {0}.{1} calls {2} which eventually calls {3} which could impact performance. Cache the result from {3} in Start or Awake instead.",
            category: DiagnosticCategories.Performance,
            defaultSeverity: DiagnosticSeverity.Warning,
            isEnabledByDefault: true,
            description: "Using Find or GetComponent in Update methods can impact performance. Cache the result on Start or Awake methods");

        public static readonly DiagnosticDescriptor DoNotUseRemoting = new DiagnosticDescriptor(
            id: DiagnosticIDs.DoNotUseRemoting,
            title: "AOT Limitation: System.Runtime.Remoting is not supported",
            messageFormat: "AOT Limitation: System.Runtime.Remoting is not supported",
            category: DiagnosticCategories.AOT,
            defaultSeverity: DiagnosticSeverity.Info,
            isEnabledByDefault: true,
            description: "AOT Limitation: System.Runtime.Remoting is not supported");

        public static readonly DiagnosticDescriptor DoNotUseReflectionEmit = new DiagnosticDescriptor(
            id: DiagnosticIDs.DoNotUseReflectionEmit,
            title: "AOT Limitation: System.Reflection.Emit is not supported.",
            messageFormat: "AOT Limitation: System.Reflection.Emit is not supported.",
            category: DiagnosticCategories.AOT,
            defaultSeverity: DiagnosticSeverity.Info,
            isEnabledByDefault: true,
            description: "AOT Limitation: System.Reflection.Emit is not supported.");

        public static readonly DiagnosticDescriptor TypeGetType = new DiagnosticDescriptor(
            id: DiagnosticIDs.TypeGetType,
            title: "AOT Limitation: Only works for looking up existing types.",
            messageFormat: "AOT Limitation: Only works for looking up existing types.",
            category: DiagnosticCategories.AOT,
            defaultSeverity: DiagnosticSeverity.Info,
            isEnabledByDefault: true,
            description: "AOT Limitation: Only works for looking up existing types.");

        public static readonly DiagnosticDescriptor DoNotUseForEachInUpdate = new DiagnosticDescriptor(
            id: DiagnosticIDs.DoNotUseForEachInUpdate,
            title: "Avoid using ForEach loops in Update methods",
            messageFormat: "The method {0}.{1} is using a ForEach loop",
            category: DiagnosticCategories.Performance,
            defaultSeverity: DiagnosticSeverity.Warning,
            isEnabledByDefault: true,
            description: "Using ForEach in an Update could be slower and use more memory than a For loop");

        public static readonly DiagnosticDescriptor UnsealedDerivedClass = new DiagnosticDescriptor(
              id: DiagnosticIDs.UnsealedDerivedClass,
              title: "Unsealed Derived Class",
              messageFormat: "Method {0} in Derived Class {1} is not sealed. Sealing the method or class improves performance.",
              category: DiagnosticCategories.Performance,
              defaultSeverity: DiagnosticSeverity.Warning,
              isEnabledByDefault: true,
              description: "Unsealed Methods in Derived classes can impact performance"
        );

        public static readonly DiagnosticDescriptor InvokeFunctionMissing = new DiagnosticDescriptor(
              id: DiagnosticIDs.InvokeFunctionMissing,
              title: "The function being invoked does not exist",
              messageFormat: "The function '{0}' is invoking the method '{1}' that does not exist",
              category: DiagnosticCategories.Performance,
              defaultSeverity: DiagnosticSeverity.Warning,
              isEnabledByDefault: true,
              description: "Invoke Function is Missing"
            );
    }
}
