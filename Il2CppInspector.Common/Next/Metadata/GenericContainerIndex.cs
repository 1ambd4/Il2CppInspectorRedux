﻿using VersionedSerialization;

namespace Il2CppInspector.Next.Metadata;

public struct GenericContainerIndex(int value) : IIndexType<GenericContainerIndex>, IReadable, IEquatable<GenericContainerIndex>
{
    public const string TagPrefix = nameof(GenericContainerIndex);

    static string IIndexType<GenericContainerIndex>.TagPrefix => TagPrefix;
    static StructVersion IIndexType<GenericContainerIndex>.AddedVersion => MetadataVersions.V390;

    private int _value = value;

    public static int Size(in StructVersion version = default, bool is32Bit = false)
        => IIndexType<GenericContainerIndex>.IndexSize(version, is32Bit);

    public void Read<TReader>(ref TReader reader, in StructVersion version = default) where TReader : IReader, allows ref struct
    {
        _value = IIndexType<GenericContainerIndex>.ReadIndex(ref reader, in version);
    }

    #region Operators + ToString

    public static implicit operator int(GenericContainerIndex idx) => idx._value;
    public static implicit operator GenericContainerIndex(int idx) => new(idx);

    public static bool operator ==(GenericContainerIndex left, GenericContainerIndex right)
        => left._value == right._value;

    public static bool operator !=(GenericContainerIndex left, GenericContainerIndex right)
        => !(left == right);

    public readonly override bool Equals(object obj)
        => obj is GenericContainerIndex other && Equals(other);

    public readonly bool Equals(GenericContainerIndex other)
        => this == other;

    public readonly override int GetHashCode()
        => HashCode.Combine(_value);

    public readonly override string ToString() => _value.ToString();

    #endregion
}