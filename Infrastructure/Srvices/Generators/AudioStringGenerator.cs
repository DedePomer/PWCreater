using NAudio.Wave;
using PWCreater.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace PWCreater.Infrastructure.Srvices.Generators
{
    public class AudioStringGenerator : IStringGenerator
    {

        private const int SampleRate = 44100;
        private const int CountBits = 16;
        private const int Channels = 1;
        private const int DeviceNumber = 0;

        private const int TimeOfRecording = 1;


        private string GenerateString()
        {
            byte audioByte;
            byte[] byteArr = new byte[2];

            WaveInEvent waveIn = new WaveInEvent();
            waveIn.DeviceNumber = DeviceNumber;
            waveIn.WaveFormat = new WaveFormat(SampleRate, CountBits, Channels);
            waveIn.BufferMilliseconds = TimeOfRecording*1;

            waveIn.DataAvailable += (sender, e) =>
            {
                audioByte = e.Buffer[0];
            };

            waveIn.StartRecording();
            Thread.Sleep(TimeOfRecording*1000);
            waveIn.StopRecording();
            waveIn.Dispose();
            waveIn = null;

            using (SHA256 mySHA256 = SHA256.Create())
            {
                var randomNumber = RandomNumberGenerator.GetInt32(Int32.MaxValue);


            }
        }


        public string[] GetGeneratedString(int stringCount)
        {
            throw new NotImplementedException();
        }

    }
}
