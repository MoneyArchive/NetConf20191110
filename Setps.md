
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