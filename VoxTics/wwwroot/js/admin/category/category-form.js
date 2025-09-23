document.addEventListener("DOMContentLoaded", () => {
    const form = document.querySelector(".category-form");
    const nameInput = document.querySelector("#CategoryName");
    const slugInput = document.querySelector("#CategorySlug");

    // Bootstrap validation
    form.addEventListener("submit", event => {
        if (!form.checkValidity()) {
            event.preventDefault();
            event.stopPropagation();
        }
        form.classList.add("was-validated");
    });

    // Auto-generate slug from name
    if (nameInput && slugInput) {
        nameInput.addEventListener("input", () => {
            let slug = nameInput.value
                .toLowerCase()
                .trim()
                .replace(/[^\w\s-]/g, "")
                .replace(/\s+/g, "-");
            slugInput.value = slug;
        });
    }

    // Alert fade-out
    const alerts = document.querySelectorAll(".alert");
    alerts.forEach(alert => {
        setTimeout(() => {
            alert.style.transition = "opacity 0.6s ease, transform 0.6s ease";
            alert.style.opacity = "0";
            alert.style.transform = "translateY(-20px)";
            setTimeout(() => alert.remove(), 600);
        }, 3000);
    });
});
