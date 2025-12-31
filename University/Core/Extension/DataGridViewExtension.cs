namespace University.Core.Extension;

public static class DataGridViewExtension
{
    public static string Select = nameof(Select);
    public static string AddClassToStudent = nameof(AddClassToStudent);
    public static string GetClassByStudent = nameof(GetClassByStudent);
    public static string GetConflictByStudent = nameof(GetConflictByStudent);


    public static void BindingSource<T>(this DataGridView dataGridView, List<T>? data)
    {
        dataGridView.AllowUserToAddRows = false;
        dataGridView.AutoGenerateColumns = false;
        var bindingSource = new BindingSource();
        bindingSource.DataSource = data;
        dataGridView.DataSource = bindingSource;
        dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
    }


    public static void CreateButtonColumn(this DataGridViewColumnCollection columns, string id, string name,
        int width = 130)
    {
        var column = columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c.Name == id);

        if (column is not null)
            return;

        var data = new DataGridViewButtonColumn
        {
            Name = id,
            HeaderText = name,
            Text = name,
            UseColumnTextForButtonValue = true,
            Width = width
        };
        columns.Add(data);
    }

    public static void CreateTextBoxColumn(this DataGridViewColumnCollection columns, string id, string title,
        int width = 220, bool isShow = true)
    {
        var column = columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c.DataPropertyName == id);

        if (column is not null)
            return;

        var newColumn = new DataGridViewTextBoxColumn
        {
            DataPropertyName = id,
            HeaderText = title,
            Width = width,
            ReadOnly = true,
            Visible = isShow
        };

        columns.Add(newColumn);
    }

    public static void CreateCheckBoxColumn(this DataGridViewColumnCollection columns, string name, string title,
        int width = 70)
    {
        var column = columns.Cast<DataGridViewColumn>()
            .FirstOrDefault(c => c.DataPropertyName.Equals(name, StringComparison.OrdinalIgnoreCase));

        if (column is not null)
        {
            column.HeaderText = title;
            column.Width = width;
            column.Name = name;
            if (column is DataGridViewCheckBoxColumn checkBoxColumn) checkBoxColumn.ThreeState = false;
            return;
        }

        var newColumn = new DataGridViewCheckBoxColumn
        {
            DataPropertyName = name,
            Name = name,
            HeaderText = title,
            Width = width,
            ThreeState = false
        };

        columns.Add(newColumn);
    }

    public static void ToggleAllCheckBoxes(this DataGridView dataGridView, string columnName, bool? state = null)
    {
        dataGridView.EndEdit();

        foreach (DataGridViewRow row in dataGridView.Rows)
        {
            if (row.IsNewRow) continue;

            var cell = row.Cells[columnName] as DataGridViewCheckBoxCell;
            if (cell == null || cell.ReadOnly) continue;

            var currentValue = Convert.ToBoolean(cell.Value ?? false);
            var newValue = state.HasValue ? state.Value : !currentValue;

            cell.Value = newValue;
        }
    }

    public static List<T> GetCheckedRows<T>(this DataGridView dataGridView, string checkBoxColumnName) where T : class
    {
        var checkedRows = new List<T>();

        dataGridView.EndEdit();

        foreach (DataGridViewRow row in dataGridView.Rows)
            if (row.Cells[checkBoxColumnName] is DataGridViewCheckBoxCell checkBoxCell)
            {
                var isChecked = false;

                if (checkBoxCell.Value != null && bool.TryParse(checkBoxCell.Value.ToString(), out var value))
                    isChecked = value;

                if (!isChecked && checkBoxCell.FormattedValue != null &&
                    bool.TryParse(checkBoxCell.FormattedValue.ToString(), out value))
                    isChecked = value;

                if (!isChecked && checkBoxCell.EditedFormattedValue is bool editedValue)
                    isChecked = editedValue;

                if (isChecked && row.DataBoundItem is T dataBoundItem) checkedRows.Add(dataBoundItem);
            }

        return checkedRows;
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
        if (!(e.RowIndex < 0 || e.ColumnIndex < 0 || e.RowIndex >= dataGridView.Rows.Count))
            return true;

        return false;
    }


    public static void AddRowNumberColumn(this DataGridView dataGridView)
    {
        if (dataGridView.Columns["RowNumber"] != null)
            return;

        var column = new DataGridViewTextBoxColumn
        {
            Name = "RowNumber",
            HeaderText = "ردیف",
            Width = 40,
            ReadOnly = true,
            SortMode = DataGridViewColumnSortMode.NotSortable
        };

        dataGridView.Columns.Insert(0, column);

        // رویدادهای لازم برای به‌روزرسانی شماره ردیف
        dataGridView.RowsAdded += (sender, e) => UpdateRowNumbers(dataGridView);
        dataGridView.RowsRemoved += (sender, e) => UpdateRowNumbers(dataGridView);
        dataGridView.DataSourceChanged += (sender, e) => UpdateRowNumbers(dataGridView);
        dataGridView.Sorted += (sender, e) => UpdateRowNumbers(dataGridView);
    }

    private static void UpdateRowNumbers(DataGridView dataGridView)
    {
        if (dataGridView.Columns["RowNumber"] == null) return;

        foreach (DataGridViewRow row in dataGridView.Rows)
            if (!row.IsNewRow)
                row.Cells["RowNumber"].Value = row.Index + 1;
    }
}