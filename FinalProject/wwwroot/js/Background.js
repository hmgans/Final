function Background() {
    var texture = PIXI.Texture.fromImage("images/full-background.png");
    PIXI.extras.TilingSprite.call(this, texture, 800, 600);

    this.position.x = 0;
    this.position.y = 0;
    this.tilePosition.x = 0;
    this.tilePosition.y = 0;

    this.viewportX = 0;
}

Background.prototype = Object.create(PIXI.extras.TilingSprite.prototype);

Background.DELTA_X = 0.05;

Background.prototype.setViewportX = function (newViewportX) {
    var distanceTravelled = newViewportX - this.viewportX;
    this.viewportX = newViewportX;
    this.tilePosition.x -= (distanceTravelled * Background.DELTA_X);
}