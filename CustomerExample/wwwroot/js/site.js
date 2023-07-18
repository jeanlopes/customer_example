// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Show notification on the screen
function showNotification(message, type) {
    // Implement your notification logic here
    // This can be done using a toast library or custom implementation
    // Example: display a Bootstrap toast message
    var notification = document.createElement("div");
    notification.classList.add("toast", "show", "position-fixed");
    notification.style.top = "10px";
    notification.style.right = "10px";
    notification.innerHTML = `
                        <div class="toast-header">
                            <strong class="mr-auto">Notification</strong>
                            <button type="button" class="ml-2 mb-1 close" data-dismiss="toast">&times;</button>
                        </div>
                        <div class="toast-body">
                            ${message}
                        </div>
                    `;
    notification.classList.add("bg-" + type);
    document.body.appendChild(notification);
    $('.toast').toast('show');
}