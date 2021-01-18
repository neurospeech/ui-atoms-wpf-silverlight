<?php get_header(); ?>

<?php get_sidebar(1); ?>

<?php if (is_home()) : ?>

<div class="indent welcome">
  <div class="text-box">
    <div class="left">
      <p class="img">
        <img alt="" src=""<?php bloginfo('stylesheet_directory'); ?>/images/1page-img1.jpg" />
      </p>
      <p>
        <a href="#">Production Premium</a>
      </p>
      <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh.</p>
      <p>
        <a class="more-link" href="#">Learn more</a>
      </p>
    </div>

    <div class="left">
      <p class="img">
        <img alt="" src=""<?php bloginfo('stylesheet_directory'); ?>/images/1page-img2.jpg" />
      </p>
      <p>
        <a href="#">Master Collections</a>
      </p>
      <p>Isum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh set.</p>
      <p>
        <a class="more-link" href="#">Learn more</a>
      </p>
    </div>

    <div class="left mr">
      <p class="img">
        <img alt="" src=""<?php bloginfo('stylesheet_directory'); ?>/images/1page-img3.jpg" />
      </p>
      <p>
        <a href="#">Production for Office</a>
      </p>
      <p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh.</p>
      <p>
        <a class="more-link" href="#">Learn more</a>
      </p>
    </div>

  </div>
</div>

<?php endif; ?>

<?php if (have_posts()) : ?>
<?php while (have_posts()) : the_post(); ?>
<div
  <?php post_class() ?> id="post-<?php the_ID(); ?>">

  <div class="indent">

    <div class="title">

      <h2>
        <a href=""
          <?php the_permalink() ?>" rel="bookmark" title="Permanent Link to <?php the_title_attribute(); ?>"><?php the_title(); ?>
        </a>
      </h2>

      <div class="date">
        <?php the_time('l, F j, Y') ?> @ <?php the_time('h:m A') ?> posted by <?php the_author_link() ?>
      </div>

    </div>

    <div class="text-box">
      <?php the_content('Read More'); ?>
    </div>

    <div class="link-edit">
      <?php edit_post_link('Edit Post', ''); ?>
    </div>

    <div class="comments">
      <?php comments_popup_link('0 Comments', '1 Comment', '% Comments', '' , 'off'); ?>
    </div>



  </div>

</div>
<?php endwhile; ?>
</div>
<div class="navigation nav-top">
  <div class="alignleft">
    <?php next_posts_link('&lt;&lt; Older Entries') ?>
  </div>
  <div class="alignright">
    <?php previous_posts_link('Newer Entries &gt;&gt;') ?>
  </div>
</div>

<?php else : ?>
<h2 class="pagetitle">Not Found</h2>
<p class="center">Sorry, but you are looking for something that isn't here.</p>
<?php get_search_form(); ?>
<?php endif; ?>

<?php get_footer(); ?>