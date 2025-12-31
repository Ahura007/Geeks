using University.Core.Const;
using University.Forms;
using University.Infra;

namespace University;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        Application.ThreadException += Application_ThreadException;
        AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        DbContext.SeedData();
        Application.Run(new Main());
    }

    private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
    {
        HandleException(e.Exception, string.Empty);
    }

    private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        if (e.ExceptionObject is Exception ex) HandleException(ex, string.Empty);
    }

    private static void HandleException(Exception ex, string exceptionType)
    {
        MessageBox.Show($"{ex.Message}\n\n{exceptionType}", Const.Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}