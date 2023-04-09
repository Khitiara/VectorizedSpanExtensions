using System.Numerics;

namespace Naive;

public class NaiveImpl
{
    public static void Add<T>(Span<T> left, ReadOnlySpan<T> right)
        where T : struct, IAdditionOperators<T, T, T> {
        if (left.Length != right.Length) {
            throw new ArgumentException($"{nameof(left)} and {nameof(right)} are not the same length");
        }

        for (int i = 0; i < left.Length; i++) {
            left[i] += right[i];
        }
    }

    public static void Multiply<T>(Span<T> left, ReadOnlySpan<T> right)
        where T : struct, IMultiplyOperators<T, T, T> {
        if (left.Length != right.Length) {
            throw new ArgumentException($"{nameof(left)} and {nameof(right)} are not the same length");
        }

        for (int i = 0; i < left.Length; i++) {
            left[i] *= right[i];
        }
    }

    public static T Dot<T>(ReadOnlySpan<T> left, ReadOnlySpan<T> right)
        where T : struct, IAdditionOperators<T, T, T>, IAdditiveIdentity<T, T>, IMultiplyOperators<T, T, T> {
        if (left.Length != right.Length) {
            throw new ArgumentException($"{nameof(left)} and {nameof(right)} are not the same length");
        }

        T result = T.AdditiveIdentity;
        for (int i = 0; i < left.Length; i++) {
            result += left[i] * right[i];
        }
        return result;
    }
}