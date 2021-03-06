﻿using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	Direction currentDir;
    Vector2 input;
    bool isMoving = false;
    Vector3 startPos;
    Vector3 endPos;
    float t;

    public Sprite northSprite;
    public Sprite eastSprite;
    public Sprite southSprite;
    public Sprite westSprite;

    public float walkSpeed = 3f;

    public bool isAllowedToMove = true;
	public string initialDir = Direction.South.ToString ();

    void Start() {
        isAllowedToMove = true;
    }

	void Update () { 
        if(!isMoving && isAllowedToMove) {
            input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
                input.y = 0;
            else
                input.x = 0;

            if(input != Vector2.zero) {

                if(input.x < 0) {
                    currentDir = Direction.West;
                } else if(input.x > 0) {
                    currentDir = Direction.East;
                }

                if(input.y < 0) {
                    currentDir = Direction.South;
                } else if (input.y > 0) {
                    currentDir = Direction.North;
                }

                switch(currentDir) {
                    case Direction.North:
                        gameObject.GetComponent<SpriteRenderer>().sprite = northSprite;
                        break;
                    case Direction.East:
                        gameObject.GetComponent<SpriteRenderer>().sprite = eastSprite;
                        break;
                    case Direction.South:
                        gameObject.GetComponent<SpriteRenderer>().sprite = southSprite;
                        break;
                    case Direction.West:
                        gameObject.GetComponent<SpriteRenderer>().sprite = westSprite;
                        break;
                }

				if (initialDir == currentDir.ToString ()) {
					StartCoroutine (Move (transform));
				} else {
					initialDir = currentDir.ToString ();
				}
            }
        }
	}

    public IEnumerator Move(Transform entity) {
        isMoving = true;
        startPos = entity.position;
        t = 0;

        endPos = new Vector3(startPos.x + System.Math.Sign(input.x), startPos.y + System.Math.Sign(input.y), startPos.z);

        while (t < 1f) {
            t += Time.deltaTime * walkSpeed;
            entity.position = Vector3.Lerp(startPos, endPos, t);
            yield return null;
        }

        isMoving = false;
        yield return 0;
    }
}

enum Direction {
    North,
    East,
    South,
    West
}
