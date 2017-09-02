namespace Task.Models
{
    public enum TaskType
    {
        None = 0,
        /// <summary>
        /// ������������ ������� ������
        /// </summary>
        Investigation = 1,
        /// <summary>
        /// �����������, �������, ��������� ������ �� ������� � ������
        /// </summary>
        Translation = 2,
        /// <summary>
        /// ���������� � ���� ������ ����� ������� �����, ������� ���������, ���������� �� �������������, ��������������
        /// </summary>
        Preparation = 3,
        /// <summary>
        /// ����������������, �������, � �.�. ����� ��� ������������, ������������ �� �������������� ������� ������ �������
        /// </summary>
        Implementation = 4,
        /// <summary>
        /// �������, ����� �����
        /// </summary>
        Debug = 5,
        /// <summary>
        /// �������� ��������, ���������������
        /// </summary>
        Review = 6,
        /// <summary>
        /// ������������ �� ������� ����� � UX
        /// </summary>
        Testing = 7,
        /// <summary>
        /// ��������� ������������, ��, ��������
        /// </summary>
        Documentation = 8,
        /// <summary>
        /// ����������������, ���������, ������ �� ����
        /// </summary>
        Consulting = 9,
        /// <summary>
        /// ����������, �������, �������������
        /// </summary>
        Communication = 10
    }
}