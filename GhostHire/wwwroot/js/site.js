// Initialize Particles.js
particlesJS("particles-js", {
    particles: {
        number: { value: 50, density: { enable: true, value_area: 900 } }, // Increased particle count
        color: { value: "#888888" }, // Neutral color for visibility
        shape: {
            type: "circle", // Changed from "triangle" to "circle" for a smoother look
            stroke: { width: 0, color: "#000000" },
            polygon: { nb_sides: 5 },
        },
        opacity: {
            value: 0.15, // Subtle transparency for better aesthetics
            random: true,
            anim: { enable: true, speed: 1, opacity_min: 0.1, sync: false }
        },
        size: {
            value: 8, // Adjusted size for visibility without clutter
            random: true,
            anim: { enable: true, speed: 20, size_min: 0.1, sync: false }
        },
        line_linked: {
            enable: true,
            distance: 120,
            color: "#888888",
            opacity: 0.2,
            width: 1
        },
        move: {
            enable: true,
            speed: 3, // Reduced speed for a calmer effect
            direction: "none",
            random: false,
            straight: false,
            out_mode: "out",
            bounce: false,
            attract: { enable: false, rotateX: 600, rotateY: 1200 }
        }
    },
    interactivity: {
        detect_on: "canvas",
        events: {
            onhover: { enable: true, mode: "repulse" },
            onclick: { enable: true, mode: "push" },
            resize: true
        },
        modes: {
            grab: { distance: 400, line_linked: { opacity: 1 } },
            bubble: { distance: 300, size: 10, duration: 2, opacity: 0.8, speed: 3 },
            repulse: { distance: 150, duration: 0.5 }, // Stronger repulse effect
            push: { particles_nb: 5 },
            remove: { particles_nb: 2 }
        }
    },
    retina_detect: true
});

// Light/Dark Mode Toggle
const toggleSwitch = document.getElementById("darkModeToggle");

toggleSwitch.addEventListener("change", function () {
    document.body.classList.toggle("light-mode");

    // Change particle colors dynamically based on mode
    let newColor = document.body.classList.contains("light-mode") ? "#ffffff" : "#888888";

    particlesJS("particles-js", {
        particles: {
            color: { value: newColor }, // Change color on mode switch
            line_linked: { color: newColor } // Update link color
        }
    });
});
