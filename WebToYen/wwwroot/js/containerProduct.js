const menuToggle = document.getElementById("menuToggle");
const sideMenu = document.getElementById("sideMenu");
const overlay = document.getElementById("overlay");
const closeBtn = document.querySelector(".close");

menuToggle.addEventListener("click", () => {
  sideMenu.classList.toggle("open");
  overlay.classList.toggle("show");
});

overlay.addEventListener("click", () => {
  sideMenu.classList.remove("open");
  overlay.classList.remove("show");
});

// Xử lý khi nhấn nút X
closeBtn.addEventListener("click", () => {
  sideMenu.classList.remove("open");
  overlay.classList.remove("show");
});



// Toggle hiển thị toàn bộ khu vực filter-wrap khi bấm "Bộ Lọc"
document.querySelectorAll('.filter-link').forEach(function (filter) {
  filter.addEventListener('click', function (e) {
    e.preventDefault();
    const parent = filter.closest('.clt-flex-reverse');
    const content = parent.querySelector('.filter-wrap');
    if (content) {
      content.classList.toggle('open');
    }
  });
});

// Toggle từng phần trong filter (Thương hiệu, Giá, Dịch vụ...)
document.querySelectorAll('.sidebar-subtitle').forEach(function (subtitle) {
  subtitle.addEventListener('click', function () {
    const parent = subtitle.closest('.sidebar-group');
    const content = parent.querySelector('.sidebar-content');
    const icon = subtitle.querySelector('.icon-control i');

    if (content.classList.contains('open')) {
      content.classList.remove('open');
      content.style.display = 'none';
      icon.classList.remove('rotate');
    } else {
      content.classList.add('open');
      content.style.display = 'block';
      icon.classList.add('rotate');
    }
  });
});


  // document.querySelectorAll('.sidebar-subtitle').forEach(function(sidebar) {
  //   sidebar.addEventListener('click', function() {
  //     const parent = sidebar.closest('.sidebar-group');
  //     const content = parent.querySelector('.sidebar-content');

  //     // Lấy style hiển thị thực tế
  //     const currentDisplay = window.getComputedStyle(content).display;

  //     // Toggle hiển thị
  //     content.style.display = (currentDisplay === 'none') ? 'block' : 'none';
  //   });
  // });


// Lấy tất cả các mũi tên và menu con
const arrows = document.querySelectorAll('.hd-top-mb-right');
const menuItems = document.querySelectorAll('.hd-top-mb-ul');

arrows.forEach((arrow, index) => {
  // Khi click vào mũi tên, thực hiện việc hiển thị/ẩn menu
  arrow.addEventListener('click', function() {
    // Lấy phần menu tương ứng với mũi tên
    const subMenu = menuItems[index];

    // Nếu menu đang mở thì đóng nó, nếu không thì mở nó
    if (subMenu.classList.contains('open')) {
      subMenu.classList.remove('open'); // Ẩn menu
      arrow.classList.remove('rotate'); // Xoay mũi tên về hướng phải
    } else {
      subMenu.classList.add('open'); // Hiển thị menu
      arrow.classList.add('rotate'); // Xoay mũi tên xuống
    }
  });
});

const btn = document.querySelector(".header-btn-categorie");
const list = document.getElementById("dropdownList");

btn.addEventListener("click", function () {
    list.classList.toggle("show");
});
document.addEventListener("click", function (e) {
    if (!btn.contains(e.target) && !list.contains(e.target)) {
        list.classList.remove("show");
    }
});










(function () {
  let currentSlide = 0;
  const track = document.getElementById('productTrack');
  const cards = document.querySelectorAll('.cn-home-top-pdt-card');
  const totalCards = cards.length;

  function getItemsToShow() {
    const w = window.innerWidth;

  if (w >= 992) return 4;
  if (w >= 768) return 3;
  if (w >= 576) return 2;
  return 1;
  }

  function updateSlidePosition() {
    const itemsToShow = getItemsToShow();
    const maxSlide = totalCards - itemsToShow;
    // cardWidth tính cả margin-right 16px
    const cardWidth = cards[0].offsetWidth + 16; 
    // giới hạn currentSlide để không vượt maxSlide
    if (currentSlide > maxSlide) currentSlide = maxSlide < 0 ? 0 : maxSlide;
    const translateX = currentSlide * cardWidth;
    track.style.transform = `translateX(-${translateX}px)`;
  }

  window.nextSlide = function () {
    const itemsToShow = getItemsToShow();
    const maxSlide = totalCards - itemsToShow;
    currentSlide = currentSlide + 1;
    if (currentSlide > maxSlide) currentSlide = 0;
    updateSlidePosition();
  };

  window.prevSlide = function () {
    const itemsToShow = getItemsToShow();
    const maxSlide = totalCards - itemsToShow;
    currentSlide = currentSlide - 1;
    if (currentSlide < 0) currentSlide = maxSlide < 0 ? 0 : maxSlide;
    updateSlidePosition();
  };

  window.addEventListener('resize', updateSlidePosition);

  // Khởi tạo vị trí slide ban đầu
  updateSlidePosition();
})();




(function () {
  let currentSlide = 0;
  const track = document.getElementById('containerProduct');
  const cards = document.querySelectorAll('.container-home-pdt');
  const totalCards = cards.length;

  function getItemsToShow() {
    const w = window.innerWidth;
 
  if (w >= 992) return 4;
  if (w >= 768) return 3;
  if (w >= 576) return 2;
  return 1;
  }

  function updateSlidePosition() {
    const itemsToShow = getItemsToShow();
    const maxSlide = totalCards - itemsToShow;
    // cardWidth tính cả margin-right 16px
    const cardWidth = cards[0].offsetWidth + 16; 
    // giới hạn currentSlide để không vượt maxSlide
    if (currentSlide > maxSlide) currentSlide = maxSlide < 0 ? 0 : maxSlide;
    const translateX = currentSlide * cardWidth;
    track.style.transform = `translateX(-${translateX}px)`;
  }

  window.nextSlideContainer = function () {
    const itemsToShow = getItemsToShow();
    const maxSlide = totalCards - itemsToShow;
    currentSlide = currentSlide + 1;
    if (currentSlide > maxSlide) currentSlide = 0;
    updateSlidePosition();
  };

  window.prevSlideContainer = function () {
    const itemsToShow = getItemsToShow();
    const maxSlide = totalCards - itemsToShow;
    currentSlide = currentSlide - 1;
    if (currentSlide < 0) currentSlide = maxSlide < 0 ? 0 : maxSlide;
    updateSlidePosition();
  };

  window.addEventListener('resize', updateSlidePosition);

  // Khởi tạo vị trí slide ban đầu
  updateSlidePosition();
})();




//(function () {
//  let currentSlide = 0;
//  const track = document.getElementById('containerProductFeatured');
//  const cards = document.querySelectorAll('.container-home-pdt-featured');
//  const totalCards = cards.length;

//  function getItemsToShow() {
//    const w = window.innerWidth;

//  if (w >= 992) return 4;
//  if (w >= 768) return 3;
//  if (w >= 576) return 2;
//  return 1;
//  }

//  function updateSlidePosition() {
//    const itemsToShow = getItemsToShow();
//    const maxSlide = totalCards - itemsToShow;
//    // cardWidth tính cả margin-right 16px
//    const cardWidth = cards[0].offsetWidth + 16; 
//    // giới hạn currentSlide để không vượt maxSlide
//    if (currentSlide > maxSlide) currentSlide = maxSlide < 0 ? 0 : maxSlide;
//    const translateX = currentSlide * cardWidth;
//    track.style.transform = `translateX(-${translateX}px)`;
//  }

//  window.nextSlideFeatured = function () {
//    const itemsToShow = getItemsToShow();
//    const maxSlide = totalCards - itemsToShow;
//    currentSlide = currentSlide + 1;
//    if (currentSlide > maxSlide) currentSlide = 0;
//    updateSlidePosition();
//  };

//  window.prevSlideFeatured = function () {
//    const itemsToShow = getItemsToShow();
//    const maxSlide = totalCards - itemsToShow;
//    currentSlide = currentSlide - 1;
//    if (currentSlide < 0) currentSlide = maxSlide < 0 ? 0 : maxSlide;
//    updateSlidePosition();
//  };

//  window.addEventListener('resize', updateSlidePosition);

//  // Khởi tạo vị trí slide ban đầu
//  updateSlidePosition();
//})();




(function () {
  let currentSlide = 0;
  const track = document.getElementById('containerProductGratitude');
  const cards = document.querySelectorAll('.container-home-pdt-gratitude');
  const totalCards = cards.length;

  function getItemsToShow() {
    const w = window.innerWidth;

  if (w >= 992) return 4;
  if (w >= 768) return 3;
  if (w >= 576) return 2;
  return 1;
  }

  function updateSlidePosition() {
    const itemsToShow = getItemsToShow();
    const maxSlide = totalCards - itemsToShow;
    // cardWidth tính cả margin-right 16px
    const cardWidth = cards[0].offsetWidth + 16; 
    // giới hạn currentSlide để không vượt maxSlide
    if (currentSlide > maxSlide) currentSlide = maxSlide < 0 ? 0 : maxSlide;
    const translateX = currentSlide * cardWidth;
    track.style.transform = `translateX(-${translateX}px)`;
  }

  window.nextSlideContainerGratitude = function () {
    const itemsToShow = getItemsToShow();
    const maxSlide = totalCards - itemsToShow;
    currentSlide = currentSlide + 1;
    if (currentSlide > maxSlide) currentSlide = 0;
    updateSlidePosition();
  };

  window.prevSlideContainerGratitude = function () {
    const itemsToShow = getItemsToShow();
    const maxSlide = totalCards - itemsToShow;
    currentSlide = currentSlide - 1;
    if (currentSlide < 0) currentSlide = maxSlide < 0 ? 0 : maxSlide;
    updateSlidePosition();
  };

  window.addEventListener('resize', updateSlidePosition);

  // Khởi tạo vị trí slide ban đầu
  updateSlidePosition();
})();




(function () {
  let currentSlide = 0;
  const track = document.getElementById('containerProductGift');
  const cards = document.querySelectorAll('.container-home-pdt-gift');
  const totalCards = cards.length;

  function getItemsToShow() {
    const w = window.innerWidth;

  if (w >= 992) return 4;
  if (w >= 768) return 3;
  if (w >= 576) return 2;
  return 1;
  }

  function updateSlidePosition() {
    const itemsToShow = getItemsToShow();
    const maxSlide = totalCards - itemsToShow;
    // cardWidth tính cả margin-right 16px
    const cardWidth = cards[0].offsetWidth + 16; 
    // giới hạn currentSlide để không vượt maxSlide
    if (currentSlide > maxSlide) currentSlide = maxSlide < 0 ? 0 : maxSlide;
    const translateX = currentSlide * cardWidth;
    track.style.transform = `translateX(-${translateX}px)`;
  }

  window.nextSlideContainerGift = function () {
    const itemsToShow = getItemsToShow();
    const maxSlide = totalCards - itemsToShow;
    currentSlide = currentSlide + 1;
    if (currentSlide > maxSlide) currentSlide = 0;
    updateSlidePosition();
  };

  window.prevSlideContainerGift = function () {
    const itemsToShow = getItemsToShow();
    const maxSlide = totalCards - itemsToShow;
    currentSlide = currentSlide - 1;
    if (currentSlide < 0) currentSlide = maxSlide < 0 ? 0 : maxSlide;
    updateSlidePosition();
  };

  window.addEventListener('resize', updateSlidePosition);

  // Khởi tạo vị trí slide ban đầu
  updateSlidePosition();
})();







(function () {
  let currentSlide = 0;
  const track = document.getElementById('containerProductBtn');
  const cards = document.querySelectorAll('.container-home-pdt-btn');
  const totalCards = cards.length;

  function getItemsToShow() {
    const w = window.innerWidth;

  if (w >= 992) return 4;
  if (w >= 768) return 3;
  if (w >= 576) return 2;
  return 1;
  }

  function updateSlidePosition() {
    const itemsToShow = getItemsToShow();
    const maxSlide = totalCards - itemsToShow;
    // cardWidth tính cả margin-right 16px
    const cardWidth = cards[0].offsetWidth + 16; 
    // giới hạn currentSlide để không vượt maxSlide
    if (currentSlide > maxSlide) currentSlide = maxSlide < 0 ? 0 : maxSlide;
    const translateX = currentSlide * cardWidth;
    track.style.transform = `translateX(-${translateX}px)`;
  }

  window.nextSlideContainerBtn = function () {
    const itemsToShow = getItemsToShow();
    const maxSlide = totalCards - itemsToShow;
    currentSlide = currentSlide + 1;
    if (currentSlide > maxSlide) currentSlide = 0;
    updateSlidePosition();
  };

  window.prevSlideContainerBtn = function () {
    const itemsToShow = getItemsToShow();
    const maxSlide = totalCards - itemsToShow;
    currentSlide = currentSlide - 1;
    if (currentSlide < 0) currentSlide = maxSlide < 0 ? 0 : maxSlide;
    updateSlidePosition();
  };

  window.addEventListener('resize', updateSlidePosition);

  // Khởi tạo vị trí slide ban đầu
  updateSlidePosition();
})();





(function () {
  let currentSlide = 0;
  const track = document.getElementById('containerProductOther');
  const cards = document.querySelectorAll('.container-home-pdt-other');
  const totalCards = cards.length;

  function getItemsToShow() {
    const w = window.innerWidth;

  if (w >= 992) return 4;
  if (w >= 768) return 3;
  if (w >= 576) return 2;
  return 1;
  }

  function updateSlidePosition() {
    const itemsToShow = getItemsToShow();
    const maxSlide = totalCards - itemsToShow;
    // cardWidth tính cả margin-right 16px
    const cardWidth = cards[0].offsetWidth + 16; 
    // giới hạn currentSlide để không vượt maxSlide
    if (currentSlide > maxSlide) currentSlide = maxSlide < 0 ? 0 : maxSlide;
    const translateX = currentSlide * cardWidth;
    track.style.transform = `translateX(-${translateX}px)`;
  }

  window.nextSlideContainerOther = function () {
    const itemsToShow = getItemsToShow();
    const maxSlide = totalCards - itemsToShow;
    currentSlide = currentSlide + 1;
    if (currentSlide > maxSlide) currentSlide = 0;
    updateSlidePosition();
  };

  window.prevSlideContainerOther = function () {
    const itemsToShow = getItemsToShow();
    const maxSlide = totalCards - itemsToShow;
    currentSlide = currentSlide - 1;
    if (currentSlide < 0) currentSlide = maxSlide < 0 ? 0 : maxSlide;
    updateSlidePosition();
  };

  window.addEventListener('resize', updateSlidePosition);

  // Khởi tạo vị trí slide ban đầu
  updateSlidePosition();
})();





(function () {
  let currentSlide = 0;
  const track = document.getElementById('containerProductNews');
  const cards = document.querySelectorAll('.container-home-pdt-news');
  const totalCards = cards.length;

  function getItemsToShow() {
    const w = window.innerWidth;
  
  if (w >= 992) return 4;
  if (w >= 768) return 3;
  if (w >= 576) return 2;
  return 1;
  }

  function updateSlidePosition() {
    const itemsToShow = getItemsToShow();
    const maxSlide = totalCards - itemsToShow;
    // cardWidth tính cả margin-right 16px
    const cardWidth = cards[0].offsetWidth + 16; 
    // giới hạn currentSlide để không vượt maxSlide
    if (currentSlide > maxSlide) currentSlide = maxSlide < 0 ? 0 : maxSlide;
    const translateX = currentSlide * cardWidth;
    track.style.transform = `translateX(-${translateX}px)`;
  }

  window.nextSlideContainerNews = function () {
    const itemsToShow = getItemsToShow();
    const maxSlide = totalCards - itemsToShow;
    currentSlide = currentSlide + 1;
    if (currentSlide > maxSlide) currentSlide = 0;
    updateSlidePosition();
  };

  window.prevSlideContainerNews = function () {
    const itemsToShow = getItemsToShow();
    const maxSlide = totalCards - itemsToShow;
    currentSlide = currentSlide - 1;
    if (currentSlide < 0) currentSlide = maxSlide < 0 ? 0 : maxSlide;
    updateSlidePosition();
  };

  window.addEventListener('resize', updateSlidePosition);

  // Khởi tạo vị trí slide ban đầu
  updateSlidePosition();
})();




document.addEventListener("DOMContentLoaded", function () {
  const btnBestSeller = document.getElementById("hd-btn-1");
  const btnFeatured = document.getElementById("hd-btn-2");

  const tabBestSeller = document.getElementById("tab-best-seller");
  const tabFeatured = document.getElementById("tab-featured");

  btnBestSeller.addEventListener("click", function () {
    // Hiện Bán Chạy, Ẩn Nổi Bật
    tabBestSeller.style.display = "block";
    tabFeatured.style.display = "none";

    // Active button
    btnBestSeller.classList.add("active");
    btnFeatured.classList.remove("active");
  });

  btnFeatured.addEventListener("click", function () {
    // Hiện Nổi Bật, Ẩn Bán Chạy
    tabBestSeller.style.display = "none";
    tabFeatured.style.display = "block";

    // Active button
    btnBestSeller.classList.remove("active");
    btnFeatured.classList.add("active");
  });
});


// product img







// click vao thi hien, click ra ngoai thi tat, (gio hang)

document.addEventListener('DOMContentLoaded', function () {
    const headerShop = document.querySelector('.header-shop');
    const headerActionDropdown = document.querySelector('.header-action-dropdown');

    // Toggle dropdown khi click vào header-shop
    headerShop.addEventListener('click', function (event) {
        event.stopPropagation();  // Ngăn chặn sự kiện click lan tỏa
        headerShop.classList.toggle('active');
    });

    // Đóng dropdown khi click ra ngoài
    document.addEventListener('click', function (event) {
        if (!headerShop.contains(event.target)) {
            headerShop.classList.remove('active');
        }
    });
});



// trong product, khi click vao them gio hang thi hien AddToCart Default.cshtml

function addToCart(productId) {
    var quantity = document.getElementById('quantity').value;

    fetch(`/Cart/Add?Id=${productId}&quantity=${quantity}`, {
        method: 'GET' // hoặc POST nếu bạn sửa lại controller
    })
        .then(response => response.json())
        .then(data => {
            if (data.success) {
                // Update nội dung modal với dữ liệu CartViewModel trả về
                updateModalContent(data.cartViewModel);

                // Hiển thị modal
                document.getElementById('modalAddComplete').classList.remove('d-none');
                document.getElementById('modalAddComplete').classList.add('d-block');
            } else {
                alert('Thêm vào giỏ hàng thất bại!');
            }
        });
}

// Đóng modal khi nhấn nút x
document.getElementById('modalAddComplete-close').onclick = function () {
    document.getElementById('modalAddComplete').classList.remove('d-block');
    document.getElementById('modalAddComplete').classList.add('d-none');
};

// Hàm update nội dung modal (ví dụ cơ bản)
function updateModalContent(cart) {
    // Ví dụ bạn có thể rebuild bảng giỏ hàng trong modal bằng JS hoặc
    // bạn có thể dùng partial view, template engine client hoặc
    // đơn giản là reload trang hoặc render phần modal server trả về html
    // Dưới đây là mẫu đơn giản:

    document.querySelector('#modalAddComplete .count').textContent = cart.count;

    // Và bạn làm tương tự để update danh sách sản phẩm, tổng tiền...
    // Tùy theo cấu trúc bạn muốn render lại modal
}



