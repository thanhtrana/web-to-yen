// start hien thi nut cham
  document.querySelectorAll('.customcol_sort span').forEach(item => {
    item.addEventListener('click', () => {
      document.querySelectorAll('.customcol_sort span').forEach(el => {
        el.classList.remove('active');
      });
      item.classList.add('active');
    });
  });
//   end hien thi nut cham

// start tao danh sach trang

const totalPages = 8; // Tổng số trang
      let currentPage = 1;

      function renderPageContent(page) {
        document.getElementById(
          "page-content"
        ).innerText = `Nội dung trang ${page}`;
      }

      function generatePagination(page, total) {
        const container = document.getElementById("pagination");
        container.innerHTML = "";
        currentPage = page;

        let start = Math.max(1, page - 2);
        let end = Math.min(total, page + 2);

        // Điều chỉnh nếu gần đầu/cuối để luôn có 5 trang nếu có thể
        if (end - start < 4) {
          if (start === 1) {
            end = Math.min(start + 4, total);
          } else if (end === total) {
            start = Math.max(end - 4, 1);
          }
        }

        // Nút prev
        if (page > 1) {
          const prevBtn = document.createElement("button");
          prevBtn.textContent = "«";
          prevBtn.onclick = () => {
            generatePagination(page - 1, total);
            renderPageContent(page - 1);
          };
          container.appendChild(prevBtn);
        }

        // Các nút số
        for (let i = start; i <= end; i++) {
          const btn = document.createElement("button");
          btn.textContent = i;
          if (i === page) btn.classList.add("active");
          btn.onclick = () => {
            generatePagination(i, total);
            renderPageContent(i);
          };
          container.appendChild(btn);
        }

        // Nút next
        if (page < total) {
          const nextBtn = document.createElement("button");
          nextBtn.textContent = "»";
          nextBtn.onclick = () => {
            generatePagination(page + 1, total);
            renderPageContent(page + 1);
          };
          container.appendChild(nextBtn);
        }
      }

      // Khởi tạo
      window.addEventListener("DOMContentLoaded", () => {
        generatePagination(currentPage, totalPages);
        renderPageContent(currentPage);
      });

      // end danh sach trang