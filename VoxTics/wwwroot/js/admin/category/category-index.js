document.addEventListener("DOMContentLoaded", function () {
    /* ===== Sidebar Toggle ===== */
    const sidebar = document.querySelector(".admin-sidebar");
    const sidebarToggle = document.querySelector(".sidebar-toggle");
    const mobileToggle = document.querySelector(".mobile-toggle");
    const mainContent = document.querySelector(".admin-main");

    sidebarToggle?.addEventListener("click", () => {
        sidebar.classList.toggle("collapsed");
        mainContent.classList.toggle("expanded");
    });

    mobileToggle?.addEventListener("click", () => {
        sidebar.classList.toggle("mobile-open");
    });

    /* ===== Confirm delete ===== */
    const deleteForms = document.querySelectorAll("form[action*='Delete']");
    deleteForms.forEach(form => {
        form.addEventListener("submit", e => {
            if (!confirm("Are you sure you want to delete this category?")) {
                e.preventDefault();
            }
        });
    });

    /* ===== Fade out alerts ===== */
    const alerts = document.querySelectorAll(".alert");
    alerts.forEach(alert => {
        setTimeout(() => {
            alert.style.transition = "opacity 0.6s ease, transform 0.6s ease";
            alert.style.opacity = "0";
            alert.style.transform = "translateY(-20px)";
            setTimeout(() => alert.remove(), 600);
        }, 3000); // 3 seconds visible
    });

    /* ===== Table row animation ===== */
    const tableRows = document.querySelectorAll(".category-table tbody tr");
    tableRows.forEach((row, index) => {
        row.style.animation = `fadeInUp 0.5s ease forwards ${index * 0.05}s`;
        row.style.opacity = 0;
    });

    /* ===== Search auto-submit on Enter ===== */
    const searchInput = document.querySelector(".category-toolbar form input[name='search']");
    if (searchInput) {
        searchInput.addEventListener("keypress", e => {
            if (e.key === "Enter") {
                e.preventDefault();
                searchInput.closest("form").submit();
            }
        });
    }

    /* ===== Page loader simulation ===== */
    const loader = document.getElementById("page-loader");
    if (loader) {
        loader.classList.add("show");
        window.addEventListener("load", () => {
            loader.classList.remove("show");
        });
    }
});
