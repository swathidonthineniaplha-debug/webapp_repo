var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => Results.Content("""
<!DOCTYPE html>
<html lang="en">
<head>
<meta charset="UTF-8">
<meta name="viewport" content="width=device-width, initial-scale=1">
<title>.NET 10 Web App</title>
<style>
:root{font-family:Segoe UI,Arial,sans-serif;color:#20243a;background:#f4f5fb}
*{box-sizing:border-box}
body{margin:0}
header{padding:22px 8%;background:#4020a5;color:white;display:flex;justify-content:space-between;align-items:center;flex-wrap:wrap;gap:12px}
header h2{margin:0}
header span{color:#d9ccff}
main{max-width:1050px;margin:40px auto;padding:0 22px}
.hero{padding:45px;border-radius:22px;background:linear-gradient(125deg,#24105e,#7549e8);color:white}
.hero h1{font-size:clamp(32px,5vw,52px);margin:15px 0}
.hero p{line-height:1.8;color:#eee7ff}
.tag{font-size:12px;font-weight:bold;letter-spacing:2px}
.grid{display:grid;grid-template-columns:repeat(auto-fit,minmax(220px,1fr));gap:18px;margin-top:25px}
.card{background:white;border:1px solid #e6e4f0;border-radius:16px;padding:24px;box-shadow:0 8px 25px #25205b0b}
.card h3{margin-top:0}
.number{font-size:30px;font-weight:bold;color:#6135d5}
p{color:#667085;line-height:1.7}
button{background:#6135d5;color:white;border:0;border-radius:9px;padding:12px 17px;font-weight:bold;cursor:pointer}
button:hover{background:#4020a5}
footer{text-align:center;padding:30px;color:#667085}
body.dark{background:#151626;color:#f5f5fa}
body.dark .card{background:#22243a;border-color:#393b55}
body.dark p,body.dark footer{color:#c2c5d7}
body.dark .number{color:#b8a2ff}
</style>
</head>
<body>
<header>
<h2>.NET <span>10</span> Web App</h2>
<button id="theme">🌙 Dark mode</button>
</header>
<main>
<section class="hero">
<div class="tag">ASP.NET CORE · .NET 10</div>
<h1>Build. Deploy. Scale.</h1>
<p>Welcome to your .NET 10 web application. Explore a modern, responsive website served directly by ASP.NET Core.</p>
<button onclick="document.getElementById('features').scrollIntoView({behavior:'smooth'})">Explore Features →</button>
</section>
<h2 id="features" style="margin-top:35px">Application Dashboard</h2>
<div class="grid">
<div class="card">
<h3>🚀 Platform</h3>
<div class="number">.NET 10</div>
<p>Built with ASP.NET Core.</p>
</div>
<div class="card">
<h3>🕒 Live Clock</h3>
<div class="number" id="clock">--:--:--</div>
<p id="date">Loading date...</p>
</div>
<div class="card">
<h3>🔢 Counter</h3>
<div class="number" id="count">0</div>
<button id="minus">−</button>
<button id="plus">+</button>
<button id="reset">Reset</button>
</div>
<div class="card">
<h3>☁️ Azure Ready</h3>
<p>This application can be published to Azure App Service using a .NET deployment workflow.</p>
<strong style="color:#12a66a">● Demo ready</strong>
</div>
</div>
<div class="card" style="margin-top:22px">
<h2>About this application</h2>
<p>This entire page is returned from a single Program.cs file. The layout uses HTML and CSS, while JavaScript powers the live clock, counter, and theme switcher.</p>
<button id="welcome">Show Welcome Message</button>
<p id="message" aria-live="polite"></p>
</div>
</main>
<footer>© <span id="year"></span> .NET 10 Web App Demo</footer>
<script>
const $=id=>document.getElementById(id);
function tick(){
const d=new Date();
$("clock").textContent=d.toLocaleTimeString();
$("date").textContent=d.toLocaleDateString(undefined,{weekday:"long",year:"numeric",month:"long",day:"numeric"});
}
tick();setInterval(tick,1000);
$("year").textContent=new Date().getFullYear();
let n=0;
$("plus").onclick=()=>{$("count").textContent=++n};
$("minus").onclick=()=>{$("count").textContent=--n};
$("reset").onclick=()=>{$("count").textContent=n=0};
$("theme").onclick=()=>{
document.body.classList.toggle("dark");
$("theme").textContent=document.body.classList.contains("dark")?"☀️ Light mode":"🌙 Dark mode";
};
$("welcome").onclick=()=>{$("message").textContent="🎉 Welcome! Your .NET 10 web app is working."};
</script>
</body>
</html>
""", "text/html; charset=utf-8"));

app.MapGet("/health", () => Results.Ok("Healthy"));

app.Run();
