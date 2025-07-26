
    // Thời gian kết thúc (ví dụ: ngày mai)
    const deadline = new Date("2025-06-02T23:59:00").getTime();

    const timer = setInterval(() => {
      const now = new Date().getTime();
      const distance = deadline - now;

      const days = Math.floor(distance / (1000 * 60 * 60 * 24));
      const hours = Math.floor((distance / (1000 * 60 * 60)) % 24);
      const minutes = Math.floor((distance / (1000 * 60)) % 60);
      const seconds = Math.floor((distance / 1000) % 60);

      document.getElementById("days").textContent = days.toString().padStart(2, '0');
      document.getElementById("hours").textContent = hours.toString().padStart(2, '0');
      document.getElementById("minutes").textContent = minutes.toString().padStart(2, '0');
      document.getElementById("seconds").textContent = seconds.toString().padStart(2, '0');

      if (distance <= 0) {
        clearInterval(timer);
        document.getElementById("countdown").innerHTML = "Hết thời gian khuyến mãi!";
        countdown.classList.add("countdown-ended");
      }
    }, 1000);
