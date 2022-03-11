using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KillBittorentie
{
	class Program
	{
		static void Main(string[] args)
		{
			bool BitTorrentStarted = false;

			while (true)
			{
				if (!BitTorrentStarted)
				{
					if (Process.GetProcessesByName("BitTorrent.exe") != null)
					{
						BitTorrentStarted = true;
						Thread.Sleep(1000);
					}
				}

				else
				{
					if (Process.GetProcessesByName("BitTorrent.exe") != null)
					{
						Process[] _processes = null;
						_processes = Process.GetProcessesByName("bittorrentie");

						foreach (Process process in _processes)
						{
							if (!process.HasExited)
							{
								process.Kill();
								Console.WriteLine($"Killed: {process.ProcessName} PID {process.Id}");
							}
						}
					}

					else
					{
						BitTorrentStarted = false;
						Thread.Sleep(1000);
					}
				}
			}
		}
	}
}
