const canvas = document.getElementById("game");
const ctx = canvas.getContext("2d");

const scoreEl = document.getElementById("score");
const bestEl = document.getElementById("best");
const speedEl = document.getElementById("speed");
const startBtn = document.getElementById("start");
const pauseBtn = document.getElementById("pause");
const resetBtn = document.getElementById("reset");
const overlay = document.getElementById("overlay");
const finalScore = document.getElementById("final-score");
const restartBtn = document.getElementById("restart");

const gridSize = 24;
const cellSize = canvas.width / gridSize;
let snake = [];
let direction = { x: 1, y: 0 };
let pendingDirection = direction;
let food = { x: 10, y: 10 };
let score = 0;
let bestScore = 0;
let speed = 6;
let timer = null;
let running = false;
let touchStart = null;

const colors = {
  background: "#0b0f14",
  grid: "#17202a",
  snakeHead: "#37e8a1",
  snakeBody: "#2d9a7d",
  food: "#ff5757",
};

function resetGame() {
  snake = [
    { x: 6, y: 12 },
    { x: 5, y: 12 },
    { x: 4, y: 12 },
  ];
  direction = { x: 1, y: 0 };
  pendingDirection = direction;
  score = 0;
  speed = 6;
  placeFood();
  updateStats();
  draw();
}

function updateStats() {
  scoreEl.textContent = score;
  bestEl.textContent = bestScore;
  speedEl.textContent = `${(speed / 6).toFixed(1)}x`;
}

function placeFood() {
  let position;
  do {
    position = {
      x: Math.floor(Math.random() * gridSize),
      y: Math.floor(Math.random() * gridSize),
    };
  } while (snake.some((segment) => segment.x === position.x && segment.y === position.y));
  food = position;
}

function drawGrid() {
  ctx.fillStyle = colors.background;
  ctx.fillRect(0, 0, canvas.width, canvas.height);
  ctx.strokeStyle = colors.grid;
  ctx.lineWidth = 1;
  for (let i = 0; i <= gridSize; i += 1) {
    const pos = i * cellSize;
    ctx.beginPath();
    ctx.moveTo(pos, 0);
    ctx.lineTo(pos, canvas.height);
    ctx.stroke();
    ctx.beginPath();
    ctx.moveTo(0, pos);
    ctx.lineTo(canvas.width, pos);
    ctx.stroke();
  }
}

function drawSnake() {
  snake.forEach((segment, index) => {
    ctx.fillStyle = index === 0 ? colors.snakeHead : colors.snakeBody;
    ctx.fillRect(segment.x * cellSize + 2, segment.y * cellSize + 2, cellSize - 4, cellSize - 4);
  });
}

function drawFood() {
  ctx.fillStyle = colors.food;
  ctx.beginPath();
  ctx.arc(
    food.x * cellSize + cellSize / 2,
    food.y * cellSize + cellSize / 2,
    cellSize / 3,
    0,
    Math.PI * 2
  );
  ctx.fill();
}

function draw() {
  drawGrid();
  drawFood();
  drawSnake();
}

function step() {
  direction = pendingDirection;
  const head = { x: snake[0].x + direction.x, y: snake[0].y + direction.y };

  if (head.x < 0 || head.y < 0 || head.x >= gridSize || head.y >= gridSize) {
    gameOver();
    return;
  }

  if (snake.some((segment) => segment.x === head.x && segment.y === head.y)) {
    gameOver();
    return;
  }

  snake.unshift(head);

  if (head.x === food.x && head.y === food.y) {
    score += 10;
    bestScore = Math.max(bestScore, score);
    if (score % 50 === 0) {
      speed += 1;
    }
    placeFood();
  } else {
    snake.pop();
  }

  updateStats();
  draw();
}

function startGame() {
  if (running) return;
  running = true;
  overlay.classList.add("hidden");
  startBtn.disabled = true;
  pauseBtn.disabled = false;
  timer = window.setInterval(step, 1000 / speed);
}

function pauseGame() {
  if (!running) return;
  running = false;
  pauseBtn.textContent = "Reprendre";
  window.clearInterval(timer);
}

function resumeGame() {
  if (running) return;
  running = true;
  pauseBtn.textContent = "Pause";
  timer = window.setInterval(step, 1000 / speed);
}

function resetAndStop() {
  running = false;
  startBtn.disabled = false;
  pauseBtn.disabled = true;
  pauseBtn.textContent = "Pause";
  window.clearInterval(timer);
  resetGame();
}

function gameOver() {
  running = false;
  window.clearInterval(timer);
  startBtn.disabled = false;
  pauseBtn.disabled = true;
  pauseBtn.textContent = "Pause";
  overlay.classList.remove("hidden");
  finalScore.textContent = `Score final: ${score}`;
}

function setDirection(next) {
  if (next.x === -direction.x && next.y === -direction.y) return;
  pendingDirection = next;
}

function handleKey(event) {
  switch (event.key) {
    case "ArrowUp":
    case "z":
    case "Z":
      setDirection({ x: 0, y: -1 });
      break;
    case "ArrowDown":
    case "s":
    case "S":
      setDirection({ x: 0, y: 1 });
      break;
    case "ArrowLeft":
    case "q":
    case "Q":
      setDirection({ x: -1, y: 0 });
      break;
    case "ArrowRight":
    case "d":
    case "D":
      setDirection({ x: 1, y: 0 });
      break;
    default:
      break;
  }
}

function handleTouchStart(event) {
  const touch = event.changedTouches[0];
  if (!touch) return;
  touchStart = { x: touch.clientX, y: touch.clientY };
}

function handleTouchEnd(event) {
  if (!touchStart) return;
  const touch = event.changedTouches[0];
  if (!touch) return;
  const dx = touch.clientX - touchStart.x;
  const dy = touch.clientY - touchStart.y;
  if (Math.abs(dx) > Math.abs(dy)) {
    if (dx > 10) setDirection({ x: 1, y: 0 });
    if (dx < -10) setDirection({ x: -1, y: 0 });
  } else {
    if (dy > 10) setDirection({ x: 0, y: 1 });
    if (dy < -10) setDirection({ x: 0, y: -1 });
  }
  touchStart = null;
}

startBtn.addEventListener("click", () => {
  if (!running) {
    startGame();
  }
});

pauseBtn.addEventListener("click", () => {
  if (running) {
    pauseGame();
  } else {
    resumeGame();
  }
});

resetBtn.addEventListener("click", resetAndStop);
restartBtn.addEventListener("click", () => {
  resetGame();
  startGame();
});

window.addEventListener("keydown", handleKey);
canvas.addEventListener("touchstart", handleTouchStart, { passive: true });
canvas.addEventListener("touchend", handleTouchEnd, { passive: true });

resetGame();
