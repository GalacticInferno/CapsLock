using Discord;
using Discord.Commands;
using NAudio;
using NAudio.Wave;
using NAudio.CoreAudioApi;
using Discord.Audio;
using System.Linq;
using System;

namespace capslockbot.Modules.Audio
{
    //WORK IN PROGRESS
    class AudioBase
    {

        public async void AudioController(string filepath)
        {
            var client = new DiscordClient();

            try
            {
                var voiceChannel = client.Servers.SingleOrDefault(s => s.Name == "Bot Testing Server")
                    .VoiceChannels.SingleOrDefault(v => v.Name == "General");
                var vClient = await client.GetService<AudioService>().Join(voiceChannel);
                SendAudio(filepath, vClient);
                PlayAudio();
            }
            catch(Exception ex)
            {
                Console.Write("Filepath: " + filepath + " Null Execption: " + ex);
            }
        }

        private void SendAudio(string filepath, IAudioClient vClient)
        {
            var channelCount = 1;
            var OutFormat = new WaveFormat(48000, 16, channelCount);
            using (var MP3Reader = new Mp3FileReader(filepath))
            using (var resampler = new MediaFoundationResampler(MP3Reader, OutFormat))
            {
                resampler.ResamplerQuality = 60;
                int blockSize = OutFormat.AverageBytesPerSecond / 50;
                byte[] buffer = new byte[blockSize];
                int byteCount;

                while ((byteCount = resampler.Read(buffer, 0, blockSize)) > 0) // Read audio into our buffer, and keep a loop open while data is present
                {
                    if (byteCount < blockSize)
                    {
                        // Incomplete Frame
                        for (int i = byteCount; i < blockSize; i++)
                            buffer[i] = 0;
                    }
                    vClient.Send(buffer, 0, blockSize); // Send the buffer to Discord
                }
            }
        }

        private void PlayAudio()
        {

        }
    }
}
