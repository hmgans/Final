function Scroller(stage) {
    this.background = new Background();
    stage.addChild(this.background);

    this.bike = new Bike();
    stage.addChild(this.bike);

    this.viewportX = 0;
}

Scroller.prototype.setViewportX = function (viewportX) {
    this.viewportX = viewportX;
    this.background.setViewportX(viewportX);
    this.bike.setViewportX(viewportX);
};

Scroller.prototype.getViewportX = function () {
    return this.viewportX;
};

Scroller.prototype.moveViewportXBy = function (dist) {
    var newViewportX = this.viewportX + dist;
    this.setViewportX(newViewportX);
};