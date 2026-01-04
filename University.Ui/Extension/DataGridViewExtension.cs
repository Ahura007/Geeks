namespace University.Ui.Extension;

public static class DataGridViewExtension
{
    public static string Select = nameof(Select);
    public static string StudentModule = nameof(StudentModule);
    public static string StudentSeminarGroup = nameof(StudentSeminarGroup);
    public static string StudentConflict = nameof(StudentConflict);

    public static void BindingSource<T>(this DataGridView dataGridView, List<T>? data)
    {
        dataGridView.AllowUserToAddRows = false;
        dataGridView.AllowUserToDeleteRows = false;
        dataGridView.AutoGenerateColumns = false;
        dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
        dataGridView.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;
        dataGridView.DefaultCellStyle.WrapMode = DataGridViewTriState.False;

        dataGridView.DataSource = new BindingSource
        {
            DataSource = data
        };

        dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
    }

    public static void CreateButtonColumn(this DataGridViewColumnCollection columns, string id, string title)
    {
        if (columns.Cast<DataGridViewColumn>().Any(c => c.Name == id))
            return;

        columns.Add(new DataGridViewButtonColumn
        {
            Name = id,
            HeaderText = title,
            Text = title,
            UseColumnTextForButtonValue = true,
            AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        });
    }

    public static void CreateTextBoxColumn(this DataGridViewColumnCollection columns, string propertyName, string title,
        bool isVisible = true)
    {
        if (columns.Cast<DataGridViewColumn>().Any(c => c.DataPropertyName == propertyName))
            return;

        columns.Add(new DataGridViewTextBoxColumn
        {
            DataPropertyName = propertyName,
            HeaderText = title,
            ReadOnly = true,
            Visible = isVisible,
            AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            Name = propertyName
        });
    }

    public static void CreateCheckBoxColumn(this DataGridViewColumnCollection columns, string propertyName,
        string title)
    {
        if (columns.Cast<DataGridViewColumn>()
            .Any(c => c.DataPropertyName.Equals(propertyName, StringComparison.OrdinalIgnoreCase)))
            return;

        columns.Add(new DataGridViewCheckBoxColumn
        {
            DataPropertyName = propertyName,
            Name = propertyName,
            HeaderText = title,
            ThreeState = false,
            AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        });
    }

    public static void ToggleAllCheckBoxes(this DataGridView dataGridView, string columnName, bool? state = null)
    {
        dataGridView.EndEdit();

        foreach (DataGridViewRow row in dataGridView.Rows)
        {
            if (row.IsNewRow)
                continue;

            if (row.Cells[columnName] is DataGridViewCheckBoxCell cell && !cell.ReadOnly)
            {
                var current = Convert.ToBoolean(cell.Value ?? false);
                cell.Value = state ?? !current;
            }
        }
    }

    public static List<T> GetCheckedRows<T>(this DataGridView dataGridView, string checkBoxColumnName) where T : class
    {
        var result = new List<T>();
        dataGridView.EndEdit();

        foreach (DataGridViewRow row in dataGridView.Rows)
        {
            if (row.IsNewRow)
                continue;

            if (row.Cells[checkBoxColumnName] is DataGridViewCheckBoxCell cell &&
                Convert.ToBoolean(cell.Value ?? false) &&
                row.DataBoundItem is T item)
                result.Add(item);
        }

        return result;
    }

    public static string GetTotalRowCount(this DataGridView dataGridView)
    {
        return $"تعداد رکورد ها: {dataGridView.RowCount}";
    }

    public static T GetRowData<T>(this DataGridView dataGridView, DataGridViewCellEventArgs e, int cell)
    {
        var cellValue = dataGridView.Rows[e.RowIndex].Cells[cell].Value;
        return (T)Convert.ChangeType(cellValue, typeof(T));
    }

    public static bool ValidateOperation(this DataGridView dataGridView, DataGridViewCellEventArgs e)
    {
        return !(e.RowIndex < 0 || e.ColumnIndex < 0 || e.RowIndex >= dataGridView.Rows.Count);
    }

    public static void AddRowNumberColumn(this DataGridView dataGridView)
    {
        if (dataGridView.Columns["RowNumber"] != null)
            return;

        dataGridView.Columns.Insert(0, new DataGridViewTextBoxColumn
        {
            Name = "RowNumber",
            HeaderText = "ردیف",
            ReadOnly = true,
            SortMode = DataGridViewColumnSortMode.NotSortable,
            AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
        });

        dataGridView.RowsAdded += (_, _) => UpdateRowNumbers(dataGridView);
        dataGridView.RowsRemoved += (_, _) => UpdateRowNumbers(dataGridView);
        dataGridView.DataSourceChanged += (_, _) => UpdateRowNumbers(dataGridView);
        dataGridView.Sorted += (_, _) => UpdateRowNumbers(dataGridView);
    }

    private static void UpdateRowNumbers(DataGridView dataGridView)
    {
        foreach (DataGridViewRow row in dataGridView.Rows)
            if (!row.IsNewRow)
                row.Cells["RowNumber"].Value = row.Index + 1;
    }
}