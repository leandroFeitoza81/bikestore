// BikeStore - Home Page Scripts

document.addEventListener('DOMContentLoaded', function() {

    // Smooth scrolling for navigation links
    document.querySelectorAll('a[href^="#"]').forEach(anchor => {
        anchor.addEventListener('click', function (e) {
            e.preventDefault();
            const target = document.querySelector(this.getAttribute('href'));
            if (target) {
                const offsetTop = target.offsetTop - 76; // Ajuste para navbar fixa
                window.scrollTo({
                    top: offsetTop,
                    behavior: 'smooth'
                });
            }
        });
    });

    // Animate elements on scroll
    const observerOptions = {
        threshold: 0.1,
        rootMargin: '0px 0px -50px 0px'
    };

    const observer = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                entry.target.classList.add('visible');
            }
        });
    }, observerOptions);

    document.querySelectorAll('.animate-on-scroll').forEach(el => {
        observer.observe(el);
    });

    // Counter animation function
    function animateCounter(element, target, duration = 2000) {
        const start = 0;
        const increment = target / (duration / 16);
        let current = start;
        const originalText = element.textContent;
        const hasPlus = originalText.includes('+');
        const hasSlash = originalText.includes('/');

        const timer = setInterval(() => {
            current += increment;
            if (current >= target) {
                if (hasSlash) {
                    element.textContent = originalText; // Mantém formato original como "24/7"
                } else {
                    element.textContent = target + (hasPlus ? '+' : '');
                }
                clearInterval(timer);
            } else {
                if (!hasSlash) {
                    element.textContent = Math.floor(current) + (hasPlus ? '+' : '');
                }
            }
        }, 16);
    }

    // Animate counters when they come into view
    const counterObserver = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                const target = entry.target;
                const originalText = target.textContent;

                // Extrair número do texto
                const numberMatch = originalText.match(/\d+/);
                if (numberMatch) {
                    const value = parseInt(numberMatch[0]);
                    animateCounter(target, value);
                }

                counterObserver.unobserve(target);
            }
        });
    }, observerOptions);

    document.querySelectorAll('.stat-number').forEach(el => {
        counterObserver.observe(el);
    });

    // Adicionar efeito hover nos cards
    document.querySelectorAll('.feature-card, .category-card').forEach(card => {
        card.addEventListener('mouseenter', function() {
            this.style.transform = 'translateY(-10px)';
        });

        card.addEventListener('mouseleave', function() {
            this.style.transform = 'translateY(0)';
        });
    });

    // Navbar transparente/sólida baseada no scroll
    const navbar = document.querySelector('.navbar');
    window.addEventListener('scroll', function() {
        if (window.scrollY > 50) {
            navbar.classList.add('navbar-scrolled');
        } else {
            navbar.classList.remove('navbar-scrolled');
        }
    });

    // Adicionar classe para navbar scrollada no CSS
    const style = document.createElement('style');
    style.textContent = `
        .navbar-scrolled {
            background-color: rgba(248, 249, 250, 0.95) !important;
            backdrop-filter: blur(10px);
        }
    `;
    document.head.appendChild(style);

});