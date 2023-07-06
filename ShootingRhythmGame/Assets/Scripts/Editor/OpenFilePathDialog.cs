using UnityEngine;
using System.Windows.Forms;
using Ookii.Dialogs;

public class OpenFilePathDialog : MonoBehaviour
{
    private VistaOpenFileDialog m_OpenFileDialog
        = new VistaOpenFileDialog();

    [SerializeField]
    private string[] m_FilePaths; // 파일 패스

    public void OnButtonOpenFile() // 버튼에 추가할 메서드
    {
        SetOpenFileDialog();
        m_FilePaths = FileOpen(m_OpenFileDialog);
    }

    string[] FileOpen(VistaOpenFileDialog openFileDialog)
    {
        var result = openFileDialog.ShowDialog();
        var filenames = result == DialogResult.OK ?
            openFileDialog.FileNames :
            new string[0];
        openFileDialog.Dispose();
        return filenames;
    }

    void SetOpenFileDialog()
    {
        m_OpenFileDialog.Title = "파일 열기";
        m_OpenFileDialog.Filter
            = "오디오 파일 |*.mp3; *.wav" +
            "|비디오 파일 |*.mp4; *.avi" +
            "|모든 파일|*.*";
        m_OpenFileDialog.FilterIndex = 1;
        m_OpenFileDialog.Multiselect = true;
    }
}