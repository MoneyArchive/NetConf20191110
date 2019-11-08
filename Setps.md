
0. 切到 Game 頁籤

1. 針對圖片設定屬性， Advanced => Generate Mip Map，用來抗鋸齒；Max Size => 1024

2. 增加 UI
    1. Canvas => Render Mode => Screen Space - Camera
    2. 將 Main Camera 拖到 Render Camera
    3. Canvas Scaler => UI Sacle Mode => Scale With Screen Size
    4. Canvas Scaler => Screen Match Mode => Expand

3. 於 Canvas 加入 Object
    1. StartPage => EmptyObject
    2. OverPage => EmptyObject
    3. CountdownPage => EmptyObject
    4. ScoreText => Text
       1. 寬高設為 100
       2. Text default value => 0
       3. Best fit => checked；max size => 100
       4. color => ffffff
       5. Pos Y => 600
       6. Font => FFFFORWA
       7. Paragraph => Alignment => all center

4. 切到 Scene 頁籤
   1. 示範 3D Camera 效果

5. 增加物件
   1. Background
      1. PosX PosY => 0
      2. Order in Layer => 10
   2. Clouds
      1. PosX PosY => 0
      2. Order in Layer => 20
   3. Stars
      1. PosX PosY => 0
      2. Order in Layer => 30
   4. Bird
      1. PosX PosY => 0
      2. ScaleX ScaleY => .75
      3. Order in Layer => 40
      4. Color => 隨意挑一個顏色