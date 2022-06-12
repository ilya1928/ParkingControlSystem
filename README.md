# ParkingControlSystem

Цільові платформи для рішень:

ParkingControl.Portal - ASP.NET Core Blazor
ParkingControl.Mobile - Xamarin
ParkingControl.Functions - Azure Functions
ParkingControl.API - ASP.NET Core Web API

Необхідні хмарні компоненти:
1. SQL база даних системи. Після її розгортання необхідно вказати Connection String та виконати міграцію.
Шлях до міграцій - ParkingControl.Database/Migrations.
Використовується EF Core 3.1.

2. Azure Blob Storage для зберігання фотографій від громадян.
До нього звертаються Portal, Mobile та Functions. Внести необхідні конфігурації до них для доступу.
(для Portal див. Configuration/BlobStorageConfiguration.cs)

3. Azure Function App для публікації ParkingControl.Functions.
Можуть працювати і локально, адже тригером є звичайний HTTP запит.

4. Налаштувати інтеграцію до сховища реєстраційних даних, з яких функція тягне інформацію.
У поточній реалізації це була окрема DB для тестових цілей. Для демонстрації можна скористатися аналогічним варіантом.

5. Azure Cognitive.
За блок розпізнавання відповідає ParkingControl.Functions.PlateRecognition/ChainFunctions/RecognizePlateByPhoto.
У поточній реалізації була орієнтована на розгорнутий ресурс Azure Cognitive.
Для демонстрації можна поставити довільну заглушку, чи інтегрувати існуючі сервіси.

6. App service.
Дві штуки. Один для Portal, інший для API. В цілому це звичайні ASP.NET Core додатки, можна за необхідності
демонстрації запускати хоч локально.

Схема компонентів:

![Components_Formal](https://user-images.githubusercontent.com/60840904/170077292-c19a8c34-d63b-419a-8a33-f00bdc74762d.jpg)

Portal.Mobile - мобільний додаток під Андроід.
Для демонстраційних цілей також може успішно працювати локально.

Посилання на скріншоти роботи за підсистемами:
https://drive.google.com/drive/folders/17BC1BqY00H_ny7v5pnkn_nIHkRFOqCYG?usp=sharing

Загальна схема процесу між підсистемами:

![image](https://user-images.githubusercontent.com/60840904/170532777-474eef80-8201-4b79-9d14-3160a380ce81.png)

