using System.Runtime.InteropServices;

namespace WF;

static class Program
{
    [STAThread]
    static void Main()
    {

        Application.SetHighDpiMode(HighDpiMode.SystemAware);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new HomePage(1));
    }
    public static void BlueButton (Button WB)
    {
        WB.BackColor = System.Drawing.Color.Navy;
        WB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        WB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        WB.ForeColor = System.Drawing.Color.White;
        WB.UseVisualStyleBackColor = false;
    }
    public static void WhiteButton(Button BB)
    {
        BB.BackColor = System.Drawing.Color.White;
        BB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        BB.ForeColor = System.Drawing.Color.Navy;
        BB.UseVisualStyleBackColor = false;
    }
    public static void RedButton(Button RB)
    {
        RB.BackColor = System.Drawing.Color.Red;
        RB.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        RB.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        RB.ForeColor = System.Drawing.Color.White;
        RB.UseVisualStyleBackColor = false;

    }
    /*[DllImport("user32.dll")]
    public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

    private const int WM_SETREDRAW = 11;

    public static void SuspendDrawing(this Control control) => SendMessage(control.Handle, WM_SETREDRAW, false, 0);

    public static void ResumeDrawing(this Control control)
    {
        SendMessage(control.Handle, WM_SETREDRAW, true, 0);
    
        control.Refresh();
    }*/
}