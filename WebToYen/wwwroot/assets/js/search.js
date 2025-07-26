document.addEventListener("DOMContentLoaded", function () {
  const searchBtn = document.getElementById("searchBtn");
  const searchInput = document.getElementById("searchInput");
  const searchError = document.getElementById("searchError");

  searchBtn.addEventListener("click", function (e) {
    e.preventDefault(); // Ngăn form tự động reload nếu nằm trong <form>

    const value = searchInput.value.trim();

    if (value === "") {
      searchError.style.display = "block"; // Hiện thông báo
    } else {
      searchError.style.display = "none";  // Ẩn nếu có nội dung
      console.log("Từ khóa tìm kiếm:", value);
    }
  });
});