function Bike() {
    var texture = PIXI.Texture.fromImage("images/bike2.png");
    PIXI.Sprite.call(this, texture, 150, 100);

    this.position.x = 300;
    this.position.y = 400;
    this.rotation = 0.4;

    this.viewportX = 0;
}

Bike.prototype = Object.create(PIXI.Sprite.prototype);


Bike.prototype.setViewportX = function (newViewportX) {
    this.viewportX = newViewportX;
}