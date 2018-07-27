using System;
using System.Threading;
using NUnit.Framework;
namespace NetSwitch.Tests.Integration
{
	public class NetSwitchHardwareTestHelper : HardwareTestHelper
	{
		public NetSwitchHardwareTestHelper()
		{
		}

		#region Enable Devices Functions
		public override void EnableDevices(bool enableSimulator)
		{
			base.EnableDevices(enableSimulator);

			PrepareDeviceForTest();
		}

		public override void WaitForDevicesToEnable()
		{
			Thread.Sleep(DelayAfterConnectingToHardware);

			// TODO: Reimplement or remove
			WaitForText("NetSwitch");

			ReadFromDeviceAndOutputToConsole();
		}
		#endregion

		#region Prepare Device Functions
		public virtual void PrepareDeviceForTest()
		{
			PrepareDeviceForTest(true);
		}

		public virtual void PrepareDeviceForTest(bool consoleWriteDeviceOutput)
		{
			if (consoleWriteDeviceOutput)
				ReadFromDeviceAndOutputToConsole();
		}
		#endregion

		#region General Device Command Settings
		public void SendDeviceCommand(string command)
		{
			WriteToDevice(command);

			WaitForMessageReceived(command);
		}

		public void WaitForMessageReceived(string message)
		{
			Console.WriteLine("");
			Console.WriteLine("Waiting for received message");
			Console.WriteLine("  Message: " + message);

			var output = String.Empty;
			var wasMessageReceived = false;

			var startTime = DateTime.Now;

			while (!wasMessageReceived)
			{
				output += ReadLineFromDevice();

				var expectedText = "Message: " + message;
				if (output.Contains(expectedText))
				{
					wasMessageReceived = true;

					Console.WriteLine("  Message was received");

					ConsoleWriteSerialOutput(output);
				}

				var hasTimedOut = DateTime.Now.Subtract(startTime).TotalSeconds > TimeoutWaitingForResponse;
				if (hasTimedOut && !wasMessageReceived)
				{
					ConsoleWriteSerialOutput(output);

					Assert.Fail("Timed out waiting for message received (" + TimeoutWaitingForResponse + " seconds)");
				}
			}
		}
		#endregion
	}
}