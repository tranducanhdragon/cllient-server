
function intSearchTable() {
    
    // Basic example
    $(document).ready(function () {
        $('#table_cong_viec').DataTable({
        "searching": true // false to disable search (or any other option)
        });
        $('.dataTables_length').addClass('bs-select');
        });
}

