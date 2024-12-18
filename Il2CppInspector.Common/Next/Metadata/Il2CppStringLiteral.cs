﻿namespace Il2CppInspector.Next.Metadata;

using VersionedSerialization.Attributes;
using StringLiteralIndex = int;

[VersionedStruct]
public partial record struct Il2CppStringLiteral
{
    public uint Length { get; private set; }
    public StringLiteralIndex DataIndex { get; private set; }
}