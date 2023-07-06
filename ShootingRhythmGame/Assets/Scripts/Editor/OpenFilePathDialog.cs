using UnityEngine;
using System.Windows.Forms;
using Ookii.Dialogs;

public class OpenFilePathDialog : MonoBehaviour
{
    private VistaOpenFileDialog m_OpenFileDialog
        = new VistaOpenFileDialog();

    [SerializeField]
    private string[] m_FilePaths; // ���� �н�

    public void OnButtonOpenFile() // ��ư�� �߰��� �޼���
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
        m_OpenFileDialog.Title = "���� ����";
        m_OpenFileDialog.Filter
            = "����� ���� |*.mp3; *.wav" +
            "|���� ���� |*.mp4; *.avi" +
            "|��� ����|*.*";
        m_OpenFileDialog.FilterIndex = 1;
        m_OpenFileDialog.Multiselect = true;
    }
}