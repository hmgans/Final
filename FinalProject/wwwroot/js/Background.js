﻿/*
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
 *    Function for loading the background image and scrolling the viewport
 */



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