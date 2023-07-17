using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster3_2 : Monster
{
    //////////////////////// 수정할거 ㅈㄴ많음
    private float delta;
    private SpriteRenderer sr;

    private float originalBGMVolume;


    public void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originalBGMVolume = BGMManager.MusicPlayer.volume; // 나중에 옵션창에서 가져와라...
    }


    public void Update()
    {
        if (this.transform.position.x - delta > 0) sr.flipX = true;
        else if (this.transform.position.x - delta < 0) sr.flipX = false;

        delta = this.gameObject.transform.position.x;
    }


    public override void Attack()
    {
        StartCoroutine(vibration());
    }


    IEnumerator vibration()
    {
        yield return null;
        StartCoroutine(Mute());
        for (int i = 0; i <= 360; i += 20)
        {
            Shoot(transform.position, 10f, i, 1);
        }

        for (int i = 0; i <= 360; i += 30)
        {
            Bullet shoot = Shoot(transform.position, 1.2f, i, 1);
            StartCoroutine(emememem(shoot));
            yield return new WaitForSeconds(0.05f);
        }
    }


    IEnumerator emememem(Bullet shoot)
    {
        int dir = 1;
        while (true)
        {
            for (int i = 0; i < 3; i++)
            {
                shoot.transform.position += new Vector3(dir * 0.03f, 0f, 0f);
                yield return new WaitForSeconds(0.02f);
            }
            dir = -dir;
        }
    }


    IEnumerator Mute()
    {
        BGMManager.MusicPlayer.volume = originalBGMVolume / 5; //일단 임시로 브금만 하고 언젠가 전체적인 효과음도
        
        yield return new WaitForSeconds(BGMManager.Bpm/30);
        BGMManager.MusicPlayer.volume = originalBGMVolume;
    }


    public override void Dead()
    {
        BGMManager.MusicPlayer.volume = originalBGMVolume;
        base.Dead();
    }
}
