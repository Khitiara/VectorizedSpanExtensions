using System.Numerics;

namespace VectorSpanMath;

public static class SpanVectorExtensions
{
    public static void Add<T>(this Span<T> left, ReadOnlySpan<T> right)
        where T : struct, IAdditionOperators<T, T, T> {
        if (left.Length != right.Length) {
            throw new ArgumentException($"{nameof(left)} and {nameof(right)} are not the same length");
        }

        int len = left.Length;
        int rem = len % Vector<T>.Count;
        int loopEnd = len - rem;
        for (int i = 0; i < loopEnd; i += Vector<T>.Count) {
            Span<T> destination = left.Slice(i, Vector<T>.Count);
            Vector<T> v1 = new(destination);
            Vector<T> v2 = new(right.Slice(i, Vector<T>.Count));
            (v1 + v2).CopyTo(destination);
        }

        for (int i = loopEnd; i < len; i++) {
            left[i] += right[i];
        }
    }
    public static void Multiply<T>(this Span<T> left, ReadOnlySpan<T> right)
        where T : struct, IMultiplyOperators<T, T, T> {
        if (left.Length != right.Length) {
            throw new ArgumentException($"{nameof(left)} and {nameof(right)} are not the same length");
        }

        int len = left.Length;
        int rem = len % Vector<T>.Count;
        int loopEnd = len - rem;
        for (int i = 0; i < loopEnd; i += Vector<T>.Count) {
            Span<T> destination = left.Slice(i, Vector<T>.Count);
            Vector<T> v1 = new(destination);
            Vector<T> v2 = new(right.Slice(i, Vector<T>.Count));
            (v1 * v2).CopyTo(destination);
        }

        for (int i = loopEnd; i < len; i++) {
            left[i] *= right[i];
        }
    }
    public static T Dot<T>(this ReadOnlySpan<T> left, ReadOnlySpan<T> right)
        where T : struct, IAdditionOperators<T, T, T>, IAdditiveIdentity<T, T>, IMultiplyOperators<T, T, T> {
        if (left.Length != right.Length) {
            throw new ArgumentException($"{nameof(left)} and {nameof(right)} are not the same length");
        }

        int len = left.Length;
        int rem = len % Vector<T>.Count;
        int loopEnd = len - rem;
        T result = T.AdditiveIdentity;
        for (int i = 0; i < loopEnd; i += Vector<T>.Count) {
            Vector<T> v1 = new(left.Slice(i, Vector<T>.Count));
            Vector<T> v2 = new(right.Slice(i, Vector<T>.Count));
            result += Vector.Dot(v1, v2);
        }

        for (int i = loopEnd; i < len; i++) {
            result += left[i] * right[i];
        }

        return result;
    }
}