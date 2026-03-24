using System;
using System.Text;

namespace CD.Unpacker
{
    class Lookup3
    {
        private static UInt32 HashCore32(Byte[] lpBuffer, Int32 dwIndex, Int32 dwLength, UInt32 dwSeed = 0)
        {
            UInt32 a, b, c;

            a = b = c = 0xDEADBEEF + (UInt32)dwLength + dwSeed;

            Int32 i = dwIndex;

            while (i + 12 < dwLength)
            {
                a += BitConverter.ToUInt32(lpBuffer, i); i += 4;
                b += BitConverter.ToUInt32(lpBuffer, i); i += 4;
                c += BitConverter.ToUInt32(lpBuffer, i); i += 4;

                a -= c;
                a ^= (c << 4) | (c >> (32 - 4));
                c += b;
                b -= a;
                b ^= (a << 6) | (a >> (32 - 6));
                a += c;
                c -= b;
                c ^= (b << 8) | (b >> (32 - 8));
                b += a;
                a -= c;
                a ^= (c << 16) | (c >> (32 - 16));
                c += b;
                b -= a;
                b ^= (a << 19) | (a >> (32 - 19));
                a += c;
                c -= b;
                c ^= (b << 4) | (b >> (32 - 4));
                b += a;
            }

            if (i < dwLength)
            {
                a += lpBuffer[i++];
            }

            if (i < dwLength)
            {
                a += (UInt32)lpBuffer[i++] << 8;
            }

            if (i < dwLength)
            {
                a += (UInt32)lpBuffer[i++] << 16;
            }

            if (i < dwLength)
            {
                a += (UInt32)lpBuffer[i++] << 24;
            }

            if (i < dwLength)
            {
                b += (UInt32)lpBuffer[i++];
            }

            if (i < dwLength)
            {
                b += (UInt32)lpBuffer[i++] << 8;
            }

            if (i < dwLength)
            {
                b += (UInt32)lpBuffer[i++] << 16;
            }

            if (i < dwLength)
            {
                b += (UInt32)lpBuffer[i++] << 24;
            }

            if (i < dwLength)
            {
                c += (UInt32)lpBuffer[i++];
            }

            if (i < dwLength)
            {
                c += (UInt32)lpBuffer[i++] << 8;
            }

            if (i < dwLength)
            {
                c += (UInt32)lpBuffer[i++] << 16;
            }

            if (i < dwLength)
            {
                c += (UInt32)lpBuffer[i] << 24;
            }

            c ^= b;
            c -= (b << 14) | (b >> (32 - 14));
            a ^= c;
            a -= (c << 11) | (c >> (32 - 11));
            b ^= a;
            b -= (a << 25) | (a >> (32 - 25));
            c ^= b;
            c -= (b << 16) | (b >> (32 - 16));
            a ^= c;
            a -= (c << 4) | (c >> (32 - 4));
            b ^= a;
            b -= (a << 14) | (a >> (32 - 14));
            c ^= b;
            c -= (b << 24) | (b >> (32 - 24));

            return c;
        }

        //same seed as in Black Desert
        public static UInt32 iGetDataHash32(Byte[] lpBuffer, UInt32 dwSeed = 0xC5EDE)
        {
            return HashCore32(lpBuffer, 0, lpBuffer.Length, dwSeed);
        }

        public static UInt32 iGetStringHash32(String m_String, Encoding m_Encoding = null)
        {
            m_Encoding = m_Encoding ?? Encoding.ASCII;

            Byte[] lpBuffer = m_Encoding.GetBytes(m_String);

            return iGetDataHash32(lpBuffer);
        }
    }
}
