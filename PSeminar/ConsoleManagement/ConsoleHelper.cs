// Dieser Code stammt von: https://stackoverflow.com/questions/15604014/no-console-output-when-using-allocconsole-and-target-architecture-x86

using Microsoft.Win32.SafeHandles;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace PSeminar.ConsoleManaging
{
    public class ConsoleHelper
    {
        private static bool _isConsoleOpen;
        public void Log(LogLevel level = LogLevel.Erfolg, string content = null)
        {
            // Sorgt dafür, dass die Konsole sich nur öffnet wenn ein Fehler auftritt
            if (!_isConsoleOpen && (level == LogLevel.Debug || level == LogLevel.Fehler))
            {
                Initialize();

                Console.Title = "P-Seminar Projekt: Wanderweg Ickelheim - LOG FENSTER - github.com/Logxn - wwww.loganthompson.de";
                Console.WriteLine($"-------- [ Log Start: {DateTime.Now} ] --------");

                _isConsoleOpen = true;
            }

            var time = DateTime.Now.ToLongTimeString();

            switch (level)
            {
                case LogLevel.Erfolg:
                    Console.WriteLine($"[{time}] - Erfolg: {content}");
                    break;
                case LogLevel.Fehler:
                    Console.WriteLine($"[{time}] - Fehler: {content}");
                    break;
                case LogLevel.Debug:
                    Console.WriteLine($"[{time} - Debug] {content}");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(level), level, null);
            }
        }



        private static void Initialize(bool alwaysCreateNewConsole = true)
        {
            var consoleAttached = true;
            if (alwaysCreateNewConsole
                || (AttachConsole(AttachParrent) == 0
                && Marshal.GetLastWin32Error() != ErrorAccessDenied))
            {
                consoleAttached = AllocConsole() != 0;
            }

            if (!consoleAttached) return;

            InitializeOutStream();
            InitializeInStream();
        }

        private static void InitializeOutStream()
        {
            var fs = CreateFileStream("CONOUT$", GenericWrite, FileShareWrite, FileAccess.Write);
            if (fs == null) return;
            var writer = new StreamWriter(fs) { AutoFlush = true };
            Console.SetOut(writer);
            Console.SetError(writer);
        }

        private static void InitializeInStream()
        {
            var fs = CreateFileStream("CONIN$", GenericRead, FileShareRead, FileAccess.Read);
            if (fs != null)
            {
                Console.SetIn(new StreamReader(fs));
            }
        }

        private static FileStream CreateFileStream(string name, uint win32DesiredAccess, uint win32ShareMode,
                                FileAccess dotNetFileAccess)
        {
            var file = new SafeFileHandle(CreateFileW(name, win32DesiredAccess, win32ShareMode, IntPtr.Zero, OpenExisting, FileAttributeNormal, IntPtr.Zero), true);
            if (file.IsInvalid) return null;

            var fs = new FileStream(file, dotNetFileAccess);
            return fs;
        }

        #region Win API Functions and Constants
        [DllImport("kernel32.dll",
            EntryPoint = "AllocConsole",
            SetLastError = true,
            CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall)]
        private static extern int AllocConsole();

        [DllImport("kernel32.dll",
            EntryPoint = "AttachConsole",
            SetLastError = true,
            CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall)]
        private static extern uint AttachConsole(uint dwProcessId);

        [DllImport("kernel32.dll",
            EntryPoint = "CreateFileW",
            SetLastError = true,
            CharSet = CharSet.Auto,
            CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr CreateFileW(
              string lpFileName,
              uint dwDesiredAccess,
              uint dwShareMode,
              IntPtr lpSecurityAttributes,
              uint dwCreationDisposition,
              uint dwFlagsAndAttributes,
              IntPtr hTemplateFile
            );

        private const uint GenericWrite = 0x40000000;
        private const uint GenericRead = 0x80000000;
        private const uint FileShareRead = 0x00000001;
        private const uint FileShareWrite = 0x00000002;
        private const uint OpenExisting = 0x00000003;
        private const uint FileAttributeNormal = 0x80;
        private const uint ErrorAccessDenied = 5;

        private const uint AttachParrent = 0xFFFFFFFF;

        #endregion
    }
}

