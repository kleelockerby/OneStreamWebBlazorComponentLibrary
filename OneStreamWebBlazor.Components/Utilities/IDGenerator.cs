﻿using System;
using System.Threading;

namespace OneStreamWebBlazor.Components.Utilities
{
    public class IDGenerator
    {
        private const string encode_32_Chars = "0123456789ABCDEFGHIJKLMNOPQRSTUV";
        private static long _lastId = DateTime.UtcNow.Ticks;

        private static readonly ThreadLocal<char[]> _charBufferThreadLocal = new ThreadLocal<char[]>(() => new char[13]);

        static IDGenerator() { }
        private IDGenerator() { }

        public static IDGenerator Instance { get; } = new IDGenerator();

        public string Generate => GenerateImpl(Interlocked.Increment(ref _lastId));

        private static string GenerateImpl(long id)
        {
            var buffer = _charBufferThreadLocal.Value;

            buffer[0] = encode_32_Chars[(int)(id >> 60) & 31];
            buffer[1] = encode_32_Chars[(int)(id >> 55) & 31];
            buffer[2] = encode_32_Chars[(int)(id >> 50) & 31];
            buffer[3] = encode_32_Chars[(int)(id >> 45) & 31];
            buffer[4] = encode_32_Chars[(int)(id >> 40) & 31];
            buffer[5] = encode_32_Chars[(int)(id >> 35) & 31];
            buffer[6] = encode_32_Chars[(int)(id >> 30) & 31];
            buffer[7] = encode_32_Chars[(int)(id >> 25) & 31];
            buffer[8] = encode_32_Chars[(int)(id >> 20) & 31];
            buffer[9] = encode_32_Chars[(int)(id >> 15) & 31];
            buffer[10] = encode_32_Chars[(int)(id >> 10) & 31];
            buffer[11] = encode_32_Chars[(int)(id >> 5) & 31];
            buffer[12] = encode_32_Chars[(int)id & 31];
            return new string(buffer, 0, buffer.Length);
        }
    }
}
