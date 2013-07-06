class LogFile
{
    private System.IO.StreamWriter SW = null;

    public LogFile(string path)
    {
        try
        {
            SW = new System.IO.StreamWriter(path + ".log", true, System.Text.Encoding.UTF8);
        }
        catch (System.IO.IOException e)
        {
            System.Windows.Forms.MessageBox.Show(e.ToString());
        }
    }

    public void writeLogLine(string line)
    {
        System.DateTime presently = System.DateTime.Now;
        line = presently.ToString() + " - " + line;
        SW.WriteLine(line);
        SW.Flush();
    }

    public void close()
    {
        this.writeLogLine("Ћог завершЄн!");
        SW.Close();
    }
}