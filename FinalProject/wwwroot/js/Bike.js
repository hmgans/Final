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
 *    Function for loading the bike image
 */

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