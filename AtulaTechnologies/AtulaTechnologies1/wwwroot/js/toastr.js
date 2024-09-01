$(document).ready(function () {
    // Check if there's a success message in TempData
    var successMessage = '@TempData["SuccessMessage"]';
    if (successMessage) {
        toastr.success(successMessage);
    }

    // Check if there's an error message in TempData
    var errorMessage = '@TempData["ErrorMessage"]';
    if (errorMessage) {
        toastr.error(errorMessage);
    }

    // Check if there's a warning message in TempData
    var warningMessage = '@TempData["WarningMessage"]';
    if (warningMessage) {
        toastr.warning(warningMessage);
    }

    // Check if there's an info message in TempData
    var infoMessage = '@TempData["InfoMessage"]';
    if (infoMessage) {
        toastr.info(infoMessage);
    }
});
<script>
    toastr.options = {
        "closeButton": true,
    "debug": false,
    "newestOnTop": false,
    "progressBar": true,
    "positionClass": "toast-top-right",
    "preventDuplicates": false,
    "onclick": null,
    "showDuration": "300",
    "hideDuration": "1000",
    "timeOut": "5000",
    "extendedTimeOut": "1000",
    "showEasing": "swing",
    "hideEasing": "linear",
    "showMethod": "fadeIn",
    "hideMethod": "fadeOut"
    };
</script>
