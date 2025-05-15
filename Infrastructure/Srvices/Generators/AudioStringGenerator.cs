using NAudio.Wave;
using PWCreater.Infrastructure.Interfaces;
using System.Security.Cryptography;
using System.Threading;

namespace PWCreater.Infrastructure.Srvices.Generators
{
    public class AudioStringGenerator : IStringGenerator
    {

        private const int SampleRate = 44100;
        private const int CountBits = 16;
        private const int Channels = 1;
        private const int DeviceNumber = 0;

        private const int TimeOfRecordingMilliseconds = 250;


        private string GenerateString()
        {
            byte audioByte = 0;


            WaveInEvent waveIn = new WaveInEvent();
            waveIn.DeviceNumber = DeviceNumber;
            waveIn.WaveFormat = new WaveFormat(SampleRate, CountBits, Channels);
            waveIn.BufferMilliseconds = TimeOfRecordingMilliseconds;

            waveIn.DataAvailable += (sender, e) =>
            {
                audioByte = e.Buffer[0];
            };

            waveIn.StartRecording();
            Thread.Sleep(TimeOfRecordingMilliseconds);
            waveIn.StopRecording();
            waveIn.Dispose();
            waveIn = null;

            return GetHASHstring(audioByte);
        }


        private string GetHASHstring(byte audioByte)
        {
            byte[] byteArr = new byte[2];
            byte[] hashArr;
            string hashStr = "";
            RandomNumberGenerator rng = RandomNumberGenerator.Create();

            using (SHA256 mySHA256 = SHA256.Create())
            {
                rng.GetBytes(byteArr, 1, 1);
                byteArr[0] = audioByte;

                hashArr = mySHA256.ComputeHash(byteArr);
                foreach (byte b in hashArr)
                {
                    hashStr += b.ToString("x2");
                }
            }
            return hashStr;
        }



        public string[] GetGeneratedString(int stringCount)
        {
            string[] hashStrigs = new string[stringCount];
            for (int i = 0; i < stringCount; i++)
            {
                hashStrigs[i] = GenerateString();
            }
            return hashStrigs;
        }

    }
}
