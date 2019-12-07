function Main() {
    this.stage = new PIXI.Container();
    this.renderer = PIXI.autoDetectRenderer(
        800,
        600,
        { view: document.getElementById("game-canvas") }
    );
    this.loadSpriteSheet();

    this.scrollSpeed = 0;

    
}

Main.MAX_SCROLL_SPEED = 150;
Main.DISTANCE_TRAVELED = 0;
Main.ACCELERATION = false;
Main.NAS = false;
Main.NAS_COUNT = 3;
Main.NAS_TIMER = 0;

Main.prototype.update = function () {
    let left = keyboard(37),
        up = keyboard(38),
        right = keyboard(39),
        down = keyboard(40)
        space = keyboard(32);

    //Accellerate
    right.press = function () {
        Main.ACCELERATION = true;
    };
    right.release = function () {
        Main.ACCELERATION = false;
    };

    space.press = function () {
        if (Main.NAS_COUNT >= 1 && Main.NAS == false) {
            Main.NAS = true;
            Main.NAS_TIMER = 1;
        }
    };

    if (Main.DISTANCE_TRAVELED == 1000) {
        this.scrollSpeed = 0;
        requestAnimationFrame(this.WinCondition.bind(this));
    }
 
    this.scroller.moveViewportXBy(this.scrollSpeed);

    if (Main.ACCELERATION && this.scrollSpeed < Main.MAX_SCROLL_SPEED) {
        this.scrollSpeed += 0.25;
    }
    if (!Main.ACCELERATION && this.scrollSpeed > 0) {
        this.scrollSpeed -= 0.5;
    }

    if (Main.NAS_TIMER >= 1 && Main.NAS_TIMER < 200) {
        this.scrollSpeed += 1;
        Main.NAS_TIMER++;
    }

    if (Main.NAS_TIMER == 200) {
        Main.NAS = false;
        Main.NAS_TIMER = 0;
        Main.NAS_COUNT--;
    }

    if (Main.NAS == false && this.scrollSpeed > Main.MAX_SCROLL_SPEED) {
        this.scrollSpeed -= 0.5;
    }



    Main.DISTANCE_TRAVELED = Main.DISTANCE_TRAVELED + (Main.scrollSpeed * 0.1);
    this.renderer.render(this.stage);
    requestAnimationFrame(this.update.bind(this));
}

Main.prototype.WinCondition = function () {

}


Main.prototype.loadSpriteSheet = function () {
    var loader = PIXI.loader;
    loader.add("background", "images/full-background.png");
    loader.add("bike", "images/bike2.png");
    loader.once("complete", this.SpriteSheetLoaded.bind(this));
    loader.load();
}

Main.prototype.SpriteSheetLoaded = function () {
    this.scroller = new Scroller(this.stage);
    requestAnimationFrame(this.update.bind(this));
}


// Code from https://github.com/kittykatattack/learningPixi#keyboard
function keyboard(keyCode) {
    var key = {};
    key.code = keyCode;
    key.isDown = false;
    key.isUp = true;
    key.press = undefined;
    key.release = undefined;
    //The `downHandler`
    key.downHandler = function (event) {
        if (event.keyCode === key.code) {
            if (key.isUp && key.press) key.press();
            key.isDown = true;
            key.isUp = false;
        }
        event.preventDefault();
    };
    //The `upHandler`
    key.upHandler = function (event) {
        if (event.keyCode === key.code) {
            if (key.isDown && key.release) key.release();
            key.isDown = false;
            key.isUp = true;
        }
        event.preventDefault();
    };
    //Attach event listeners
    window.addEventListener(
        "keydown", key.downHandler.bind(key), false
    );
    window.addEventListener(
        "keyup", key.upHandler.bind(key), false
    );
    return key;
}