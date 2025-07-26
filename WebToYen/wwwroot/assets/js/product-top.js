(function () {
  let currentSlide = 0;
  const track = document.getElementById('containerProductNews');
  const cards = document.querySelectorAll('.container-home-pdt-news');
  const totalCards = cards.length;

  function getItemsToShow() {
    const w = window.innerWidth;
    if (w >= 992) return 4;
    if (w >= 768) return 3;
    return 2;
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
