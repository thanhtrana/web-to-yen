function minusQuantity() {
    let qtyInput = document.getElementById('quantity');
    let current = parseInt(qtyInput.value);
    if (current > 1) {
        qtyInput.value = current - 1;
    }
}

function plusQuantity() {
    let qtyInput = document.getElementById('quantity');
    let current = parseInt(qtyInput.value);
    qtyInput.value = current + 1;
}


  const stars = document.querySelectorAll('#stars li');

  stars.forEach((star, index) => {
    star.addEventListener('click', () => {
      const rating = index + 1;

      stars.forEach((s, i) => {
        if (i < rating) {
          s.classList.add('selected');
        } else {
          s.classList.remove('selected');
        }
      });

      console.log("Bạn đã đánh giá:", rating);
      // Bạn có thể gán giá trị này vào input ẩn để gửi về server
    });
  });

  // hinh anh, trong phan danh gia
const imageInput = document.getElementById("imageUpload");
  const previewContainer = document.getElementById("previewContainer");

  // Lưu trữ ảnh đã chọn (tránh trùng)
  let selectedFiles = [];

  imageInput.addEventListener("change", function () {
    const newFiles = Array.from(this.files);

    newFiles.forEach((file) => {
      // Kiểm tra trùng file (dựa trên tên và size)
      if (
        selectedFiles.some(
          (f) => f.name === file.name && f.size === file.size
        )
      ) {
        return;
      }

      selectedFiles.push(file);

      const reader = new FileReader();
      reader.onload = function (e) {
        const wrapper = document.createElement("div");
        wrapper.classList.add("image-wrapper");

        const img = document.createElement("img");
        img.src = e.target.result;
        img.classList.add("image-preview");

        const deleteBtn = document.createElement("button");
        deleteBtn.classList.add("delete-btn");
        deleteBtn.innerHTML = "&times;";

        deleteBtn.onclick = function () {
          previewContainer.removeChild(wrapper);
          selectedFiles = selectedFiles.filter(
            (f) => !(f.name === file.name && f.size === file.size)
          );
        };

        wrapper.appendChild(img);
        wrapper.appendChild(deleteBtn);
        previewContainer.appendChild(wrapper);
      };

      reader.readAsDataURL(file);
    });

    // Reset input để có thể chọn lại file cũ nếu cần
    this.value = "";
  });


  // an form
// document.querySelectorAll('.tab-pane-star-comment').forEach(function (toggleBtn) {
//   toggleBtn.addEventListener('click', function (e) {
//     e.preventDefault();
//     const form = document.querySelector('.tab-pane-form-cover');
//     if (form) {
//       form.classList.toggle('open');
//     }
//   });
// });

// document.querySelectorAll('.tab-pane-star-question').forEach(function (toggleBtn) {
//   toggleBtn.addEventListener('click', function (e) {
//     e.preventDefault();
//     const form = document.querySelector('.tab-pane-form-review');
//     if (form) {
//       form.classList.toggle('open');
//     }
//   });
// });

// Xử lý nút "Viết đánh giá"
document.querySelectorAll('.tab-pane-star-comment').forEach(function (toggleBtn) {
  toggleBtn.addEventListener('click', function (e) {
    e.preventDefault();

    const reviewForm = document.querySelector('.tab-pane-form-cover');  // Form đánh giá
    const questionForm = document.querySelector('.tab-pane-form-review');  // Form câu hỏi

    // Toggle form đánh giá
    if (reviewForm) {
      reviewForm.classList.toggle('open');
    }

    // Luôn ẩn form câu hỏi khi mở đánh giá
    if (questionForm) {
      questionForm.classList.remove('open');
    }
  });
});

// Xử lý nút "Đặt câu hỏi"
document.querySelectorAll('.tab-pane-star-question').forEach(function (toggleBtn) {
  toggleBtn.addEventListener('click', function (e) {
    e.preventDefault();

    const reviewForm = document.querySelector('.tab-pane-form-cover');  // Form đánh giá
    const questionForm = document.querySelector('.tab-pane-form-review');  // Form câu hỏi

    // Toggle form câu hỏi
    if (questionForm) {
      questionForm.classList.toggle('open');
    }

    // Luôn ẩn form đánh giá khi mở câu hỏi
    if (reviewForm) {
      reviewForm.classList.remove('open');
    }
  });
});


// click

// Lấy tất cả tab
document.querySelectorAll('.star-ft-name').forEach(function (tab) {
  tab.addEventListener('click', function () {
    // Xóa class 'active' khỏi tất cả tab
    document.querySelectorAll('.star-ft-name').forEach(function (t) {
      t.classList.remove('active');
    });

    // Thêm class 'active' cho tab được click
    tab.classList.add('active');
  });
});


document.addEventListener("DOMContentLoaded", function () {
    const thumbsSwiper = new Swiper(".thumbs-swiper", {
        slidesPerView: 4,
        spaceBetween: 10,
        slideToClickedSlide: true,
        watchSlidesProgress: true,
        watchSlidesVisibility: true,
        centeredSlides: false,
    });

    const mainImage = document.getElementById("main-image");
    const firstThumb = document.querySelector("#thumb-container img");
    if (firstThumb) {
        mainImage.src = firstThumb.src;
        firstThumb.classList.add("active");
    }

    thumbsSwiper.on("click", function (swiper) {
        const clickedIndex = swiper.clickedIndex;
        if (clickedIndex !== undefined) {
            const clickedSlide = swiper.slides[clickedIndex];
            const clickedImage = clickedSlide.querySelector("img");

            // Đổi ảnh chính
            mainImage.src = clickedImage.src;

            // Highlight ảnh được chọn
            document
                .querySelectorAll(".thumbs-swiper img")
                .forEach((img) => img.classList.remove("active"));
            clickedImage.classList.add("active");

            // Cuộn đến ảnh đang click
            swiper.slideTo(clickedIndex);
        }
    });
});


