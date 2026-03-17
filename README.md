# Hello Raylib C# - Pong Game Starter Template

<div align="center">
  <img src="HelloRaylibCs/ping-pong.png" alt="Pong Game Icon" width="128" height="128" />

  **A modern C# Pong game starter template using Raylib**

  [![.NET](https://img.shields.io/badge/.NET-10-blue)](https://dotnet.microsoft.com/)
  [![C#](https://img.shields.io/badge/C%23-14.0-green)](https://learn.microsoft.com/en-us/dotnet/csharp/)
  [![Raylib](https://img.shields.io/badge/Raylib-7.0.2-orange)](https://github.com/usagi/Raylib-cs)
  [![License](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)
</div>

---

## 🎮 About

**Hello Raylib C#** is a lightweight, beginner-friendly starter template for game development using C# and Raylib. It includes a fully functional Pong game implementation that demonstrates core game development concepts like collision detection, sprite movement, and game state management.

Perfect for learning game development with C# or as a foundation for your next Raylib project!

## ✨ Features

- 🎯 **Complete Pong Implementation** - Two-player pong game with score tracking
- 🚀 **Modern C# Stack** - Built on .NET 10 with C# 14.0
- 🎨 **Clean Architecture** - Well-organized utility functions for game logic
- ⚡ **High Performance** - Optimized rendering with monitor refresh rate sync
- 🔧 **Easy to Extend** - Simple, modular code structure for adding new features
- 📦 **Minimal Dependencies** - Only requires Raylib-cs package

## 🛠️ Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Visual Studio 2026 Community](https://visualstudio.microsoft.com/community/) or any .NET-compatible IDE
- Basic C# knowledge

## 📋 Project Structure

```
HelloRaylibCs/
├── Program.cs              # Main game loop and initialization
├── lib/
│   └── utils.cs           # Utility functions (collision detection, paddle movement)
├── ping-pong.png          # Game icon (PNG format)
├── ping-pong.ico          # App icon (Windows format)
├── HelloRaylibCs.csproj   # Project configuration
└── README.md              # This file
```

## 🚀 Quick Start

### Clone the Repository

```bash
git clone https://github.com/Ayush2006128/HelloRaylibCs.git
cd HelloRaylibCs
```

### Build the Project

```bash
dotnet build
```

### Run the Game

```bash
dotnet run
```

Or run the compiled executable from the `bin/Debug/net10.0/` directory.

## 🎮 How to Play

### Controls

**Left Player (WASD Keys)**
- **W** - Move paddle up
- **S** - Move paddle down

**Right Player (Arrow Keys)**
- **⬆️ Up** - Move paddle up
- **⬇️ Down** - Move paddle down

**General**
- **ESC** - Close the game

### Gameplay

- The ball bounces off the top and bottom walls
- Each player tries to prevent the ball from reaching their side
- The ball bounces off paddles and reverses direction
- Score is displayed for tracking game progress

## 📚 Code Highlights

### Collision Detection (`lib/utils.cs`)

```csharp
public static void CheckBallCollisions(float ballX, float ballY, int ballRadius,
    Rectangle leftpaddle, Rectangle rightpaddle, ref float ballSpeedX, ref float ballSpeedY)
{
    // Wall collision
    if (ballY <= 0 || ballY >= 450)
        ballSpeedY = -ballSpeedY;

    // Paddle collision
    if (ballX - ballRadius <= leftpaddle.X + leftpaddle.Width &&
        ballY >= leftpaddle.Y && ballY <= leftpaddle.Y + leftpaddle.Height)
        ballSpeedX = -ballSpeedX;
}
```

### Paddle Movement (`lib/utils.cs`)

```csharp
public static void Movepaddle(ref Rectangle paddle, string keyGroup, float changeValue)
{
    KeyboardKey upKey = keyGroup == "arrows" ? KeyboardKey.Up : KeyboardKey.W;
    KeyboardKey downKey = keyGroup == "arrows" ? KeyboardKey.Down : KeyboardKey.S;

    if (Raylib.IsKeyDown(upKey) && paddle.Y > 0)
        paddle.Y -= changeValue;
    else if (Raylib.IsKeyDown(downKey) && paddle.Y < 360)
        paddle.Y += changeValue;
}
```

## 🔌 Dependencies

- **Raylib-cs** (v7.0.2) - C# bindings for Raylib graphics library
  - High-level graphics and game framework
  - Cross-platform support (Windows, Linux, macOS)

## 🛠️ Extending the Project

### Add New Features

1. **Add Sound Effects** - Use Raylib's audio functions
   ```csharp
   Sound pingSound = Raylib.LoadSound("./ping.wav");
   Raylib.PlaySound(pingSound);
   ```

2. **Add AI Opponent** - Implement computer player logic
3. **Add Power-ups** - Extend the game with special items
4. **Improve Graphics** - Add sprites, animations, and visual effects
5. **Add Menu System** - Create start/pause/game over screens

### Modify Game Settings

Edit `Program.cs` to customize:
- Window size: `Raylib.InitWindow(800, 450, "Title")`
- Frame rate: `Raylib.SetTargetFPS(60)`
- Paddle size/speed
- Ball physics

## 📖 Learning Resources

- [Raylib-cs Documentation](https://github.com/usagi/Raylib-cs)
- [Raylib Official Website](https://www.raylib.com/)
- [C# Documentation](https://learn.microsoft.com/en-us/dotnet/csharp/)
- [Game Development Concepts](https://www.raylib.com/examples.html)

## 🤝 Contributing

Contributions are welcome! Here's how:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👨‍💻 Author

**Ayush** - [GitHub Profile](https://github.com/Ayush2006128)

## 🙋 Support

Have questions or found a bug? Feel free to:
- Open an [issue](https://github.com/Ayush2006128/HelloRaylibCs/issues)
- Check existing discussions and FAQs
- Reach out via GitHub discussions

---

<div align="center">

**Made with ❤️ using C# and Raylib**

⭐ If you found this helpful, please consider giving it a star!

</div>