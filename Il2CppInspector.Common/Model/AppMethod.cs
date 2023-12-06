﻿/*
    Copyright 2020-2021 Katy Coe - http://www.djkaty.com - https://github.com/djkaty
    Copyright 2023 LukeFZ - https://github.com/LukeFZ
    All rights reserved.
*/

using System.Diagnostics;
using Il2CppInspector.Cpp;
using Il2CppInspector.Reflection;
using System.Text;

namespace Il2CppInspector.Model
{
    // Class that represents a composite IL/C++ method
    public class AppMethod
    {
        // The logical group this method is part of
        // This is purely for querying methods in related groups and has no bearing on the code
        public string Group { get; set; }

        // The corresponding C++ function pointer type
        public CppFnPtrType CppFnPtrType { get; internal set; }

        // The corresponding .NET method
        public MethodBase Method { get; internal set; }

        // The VA of the MethodInfo* (VA of the pointer to the MethodInfo) object which defines this method
        // Methods not referenced by the binary will be 0xffffffff_ffffffff
        public ulong MethodInfoPtrAddress { get; internal set; } 

        // The VA of the method code itself
        // Generic method definitions do not have a code address but may have a reference above
        public ulong MethodCodeAddress => Method.VirtualAddress?.Start ?? 0xffffffff_ffffffff;

        // Helpers
        public bool HasMethodInfo => MethodInfoPtrAddress != 0xffffffff_ffffffff;
        public bool HasCompiledCode => Method.VirtualAddress.HasValue && Method.VirtualAddress.Value.Start != 0;

        public AppMethod(MethodBase method, CppFnPtrType cppMethod, ulong methodInfoPtr = 0xffffffff_ffffffff) {
            Method = method;
            CppFnPtrType = cppMethod;
            MethodInfoPtrAddress = methodInfoPtr;
        }

        public override string ToString() => CppFnPtrType.ToSignatureString();

        public string ToMangledString() => MangledNameBuilder.Method(Method);
        public string ToMangledMethodInfoString() => MangledNameBuilder.MethodInfo(Method);
    }
}
