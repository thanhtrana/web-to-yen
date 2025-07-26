

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




(function () {
  let currentSlide = 0;
  const track = document.getElementById('containerProductFeatured');
  const cards = document.querySelectorAll('.container-home-pdt-featured');
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

  window.nextSlideFeatured = function () {
    const itemsToShow = getItemsToShow();
    const maxSlide = totalCards - itemsToShow;
    currentSlide = currentSlide + 1;
    if (currentSlide > maxSlide) currentSlide = 0;
    updateSlidePosition();
  };

  window.prevSlideFeatured = function () {
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
