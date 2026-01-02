using University.Infra;
using University.Infra.Core.Const;

namespace University.Ui;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        System.Windows.Forms.Application.ThreadException += Application_ThreadException;
        AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
        System.Windows.Forms.Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
        System.Windows.Forms.Application.EnableVisualStyles();
        System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);

        DbContext.SeedData();
        System.Windows.Forms.Application.Run(new Main());
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