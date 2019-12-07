/*
 * Authors:   Jonathon Smith and Giovanni Varuloa and Hank Gansert
 * Date:      12/5/19
 * Course:    CS 4540, University of Utah, School of Computing
 * Copyright: CS 4540 and Jonathon Smith - This work may not be copied for use in Academic Coursework.
 *
 * I, Jonathon Smith and Giovanni Varula and Hank Gansert, certify that I wrote this code from scratch and did not copy it in part or whole from
 * another source.  Any references used in the completion of the assignment are cited in my README file.
 *
 * File Contents
 *
 *   Adds sprites to the stage, and creates viewports. 
 */

// Add sprites to stage
function Scroller(stage) {
    this.background = new Background();
    stage.addChild(this.background);

    this.bike = new Bike();
    stage.addChild(this.bike);

    this.viewportX = 0;
}

//Set Viewport
Scroller.prototype.setViewportX = function (viewportX) {
    this.viewportX = viewportX;
    this.background.setViewportX(viewportX);
    this.bike.setViewportX(viewportX);
};

Scroller.prototype.getViewportX = function () {
    return this.viewportX;
};

// Move viewport
Scroller.prototype.moveViewportXBy = function (dist) {
    var newViewportX = this.viewportX + dist;
    this.setViewportX(newViewportX);
};