function intSearchTable() {
    
    // Basic example
    $(document).ready(function () {
        $('#table_employee').DataTable({
        "searching": true // false to disable search (or any other option)
        });
        $('.dataTables_length').addClass('bs-select');
        });
}

